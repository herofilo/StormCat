using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSAddonLib.Domain.Addon;
using MSAddonLib.Persistence.AddonDB;

namespace StormCat.Domain
{
    public sealed class AddonBasicInfoSet
    {
        private static string _moviestormContentPackPath;

        public static string MoviestormContentPackPath
        {
            get { return _moviestormContentPackPath; }
            set
            {
                _moviestormContentPackPath = value;
                AddonBasicInfo.MoviestormContentPackPath = _moviestormContentPackPath;
            }
        }


        public List<AddonBasicInfo> Addons { get; private set; }

        public int DuplicatesFound { get; private set; }

        public int DuplicateGroups { get; private set; }

        // ---------------------------------------------------------------------------------------------------------

        public AddonBasicInfoSet(List<AddonPackage> pAddons)
        {
            List<AddonBasicInfo>  addons = new List<AddonBasicInfo>();
            if (pAddons == null)
                return;
            foreach(AddonPackage addon in pAddons) 
                addons.Add(new AddonBasicInfo(addon));

            Addons = addons.OrderBy(o => o.Name).ToList();
            
            List<AddonDupSet> dupSets = CheckAddonDuplicates();
            if (dupSets == null)
                return;

            SetDupSetIds(dupSets);
        }

        private void SetDupSetIds(List<AddonDupSet> pDupSets)
        {
            Dictionary<string, int> locationToDupSetId = new Dictionary<string, int>();
            int id = 1;
            foreach (AddonDupSet set in pDupSets)
            {
                foreach (string location in set.Locations)
                {
                    locationToDupSetId.Add(location, id);
                }

                id++;
            }

            foreach (AddonBasicInfo addon in Addons)
            {
                if (locationToDupSetId.ContainsKey(addon.Location))
                    addon.DuplicateGroup = locationToDupSetId[addon.Location];
            }

            DuplicateGroups = id - 1;
            DuplicatesFound = locationToDupSetId.Count;
        }


        // TODO : Better duplicate detection - so far it only looks at the qualified name
        private List<AddonDupSet> CheckAddonDuplicates()
        {
            if ((Addons == null) || (Addons.Count < 2))
                return null;

            List<AddonDupSet> tempDupSets = new List<AddonDupSet>();
            foreach (AddonBasicInfo addon in Addons)
            {
                if (addon.Installed)
                    continue;

                string qualifiedName = $"{addon.Publisher}.{addon.Name}";
                AddonDupSet dupSet = FindDupSet(tempDupSets, addon);
                if (dupSet == null)
                {
                    dupSet = new AddonDupSet(addon);
                    tempDupSets.Add(dupSet);
                }                 
                dupSet.AddLocation(addon.Location);
            }

            List<AddonDupSet> dupSets = new List<AddonDupSet>();
            foreach (AddonDupSet set in tempDupSets)
                if (set.Locations.Count > 1)
                    dupSets.Add(set);

            if (dupSets.Count == 0)
                return null;

            return dupSets.OrderBy(o => o.QualifiedName).ToList();
        }


        private AddonDupSet FindDupSet(List<AddonDupSet> pDupSets, AddonBasicInfo pAddonBasicInfo)
        {
            foreach (AddonDupSet set in pDupSets)
                if (set.IsMatch(pAddonBasicInfo))
                    return set;

            return null;
        }
        
    }


    [Flags]
    public enum DuplicateDetectionFlag
    {
        None = 0,
        RecompilableFlag = 0x0001,
        Name = 0x0002,
        Publisher = 0x0004,
        LastCompiled = 0x0008,
        AssetCount = 0x0010,
        MeshDataSize = 0x0020,
        TotalFiles = 0x0040
    }


    public sealed class AddonDupSet
    {

        public const DuplicateDetectionFlag DefaultDuplicateDetectionFlag = DuplicateDetectionFlag.Name | DuplicateDetectionFlag.Publisher | DuplicateDetectionFlag.LastCompiled |
                                                                            DuplicateDetectionFlag.RecompilableFlag;

        public const DuplicateDetectionFlag ForcedDuplicateDetectionFlags = DuplicateDetectionFlag.RecompilableFlag;

        private static DuplicateDetectionFlag _duplicateDetectionFlag = DefaultDuplicateDetectionFlag;

        public static DuplicateDetectionFlag DuplicateDetectionFlag
        {
            get { return _duplicateDetectionFlag; }
            set { _duplicateDetectionFlag = value | ForcedDuplicateDetectionFlags; }
        }


        public string Name { get; private set; }

        public string Publisher { get; private set; }

        public string QualifiedName { get; private set; }

        /// <summary>
        /// Used for identifying duplicates
        /// </summary>
        public string FingerPrint { get; private set; }

        public List<string> Locations { get; private set; }

        // ---------------------------------------------------------


        public AddonDupSet(AddonBasicInfo pAddonBasicInfo)
        {
            Name = pAddonBasicInfo.Name;
            Publisher = pAddonBasicInfo.Publisher;
            QualifiedName = $"{Publisher}.{Name}";
            FingerPrint = GetFingerPrint(pAddonBasicInfo);
        }


        public bool AddLocation(string pLocation)
        {
            if (string.IsNullOrEmpty(pLocation = pLocation.Trim()))
                return false;
            if (Locations == null)
            {
                Locations = new List<string>();
                Locations.Add(pLocation);
                return true;
            }

            if (Locations.Contains(pLocation))
                return false;
            Locations.Add(pLocation);
            return true;
        }

        // Used for identifying duplicates
        public static string GetFingerPrint(AddonBasicInfo pAddonBasicInfo)
        {
            StringBuilder fingerprintBuilder = new StringBuilder();
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.RecompilableFlag))
                fingerprintBuilder.Append($"R:{pAddonBasicInfo.AddonPackage.Recompilable}^");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.Publisher))
                fingerprintBuilder.Append($"P:{pAddonBasicInfo.AddonPackage.Publisher}^");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.Name))
                fingerprintBuilder.Append($"N:{pAddonBasicInfo.AddonPackage.Name}^");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.LastCompiled))
                fingerprintBuilder.Append($"LC:{pAddonBasicInfo.AddonPackage.LastCompiled:s}^");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.MeshDataSize))
            {
                if (!pAddonBasicInfo.AddonPackage.MeshDataSizeMbytes.HasValue)
                    fingerprintBuilder.Append("M:_^");
                else
                {
                    fingerprintBuilder.Append($"M:{pAddonBasicInfo.AddonPackage.MeshDataSizeMbytes.Value:F5}^");
                }
            }
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.AssetCount))
            {
                AddonAssetSummary summary = pAddonBasicInfo.AddonPackage.AssetSummary;
                fingerprintBuilder.Append(
                    $"A:{summary.Animations}_{summary.Bodyparts}_{summary.Decals}_{summary.CuttingRoomAssets}_{summary.Materials}_{summary.Props}:{summary.PropVariants}_{summary.SkyTextures}_{summary.Sounds}_{summary.SpecialEffects}_{summary.OtherAssets}_{summary.StartMovies}_{summary.Stocks}_{summary.Verbs}^");
            }
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.TotalFiles))
            {
                fingerprintBuilder.Append($"F:{pAddonBasicInfo.AddonPackage?.FileSummaryInfo.TotalFiles ?? 0}^");
            }

            return fingerprintBuilder.ToString();
        }


        public bool IsMatch(AddonBasicInfo pAddonBasicInfo)
        {
            return (GetFingerPrint(pAddonBasicInfo) == FingerPrint);
        }

        public static string GetDuplicateDetectionCriteria()
        {
            StringBuilder builder = new StringBuilder();
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.Name))
                builder.Append(" Name,");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.Publisher))
                builder.Append(" Publisher,");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.RecompilableFlag))
                builder.Append(" Republishable,");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.LastCompiled))
                builder.Append(" Last published,");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.AssetCount))
                builder.Append(" Asset count,");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.MeshDataSize))
                builder.Append(" Mesh data size,");
            if (DuplicateDetectionFlag.HasFlag(DuplicateDetectionFlag.TotalFiles))
                builder.Append(" File count,");
            string text = builder.ToString();

            return text.Substring(0, text.Length - 1).Trim();
        }
    }

}
