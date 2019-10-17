using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using MSAddonLib.Persistence.AddonDB;
using MSAddonLib.Util;
using MSAddonLib.Util.Persistence;
using StormCat.Configuration;

namespace StormCat.Persistence
{
    [Serializable]
    public sealed class CataloguesIndex : ConfigurationFileBase
    {
        public static string CataloguesIndexFilePath => Path.Combine(Utils.GetExecutableDirectory(), "CataloguesIndex.xml");

        public List<CatalogueInfo> Catalogues { get; set; }

        [XmlIgnore]
        public string DefaultAddonDatabaseFilename => string.IsNullOrEmpty(DefaultAddonDatabase)
            ? null
            : DefaultAddonDatabase + AddonPackageSet.AddonPackageSetFileExtension;

        public string DefaultAddonDatabase { get; set; } = AddonPackageSet.DefaultAddonPackageSet;


        // ----------------------------------------------------------------------------------------------------------------------

        public CatalogueInfo GetByName(string pName)
        {
            int index = GetIndexByName(pName);
            if (index < 0)
                return null;
            return Catalogues[index];
        }


        public int GetIndexByName(string pName)
        {
            if ((Catalogues == null) || (Catalogues.Count == 0))
                return -1;
            if (string.IsNullOrEmpty(pName = pName?.Trim().ToLower()))
                return -1;

            for (int index = 0; index < Catalogues.Count; ++index)
                if (pName == Catalogues[index].Name.ToLower())
                    return index;

            return -1;
        }


        public int Rename(string pOldName, string pNewName, bool pAutoSave = true)
        {
            if (string.IsNullOrEmpty(pOldName = pOldName?.Trim()) || string.IsNullOrEmpty(pNewName = pNewName?.Trim()))
                return -1;

            int oldIndex = GetIndexByName(pOldName);
            if (oldIndex < 0)
                return -1;

            int newIndex = GetIndexByName(pNewName);
            if (newIndex >= 0)
                return -1;

            Catalogues[oldIndex].Name = pNewName;

            List<CatalogueInfo> catalogues = Catalogues.OrderBy(o => o.FilePath).ToList();
            Catalogues = catalogues;

            string errorText;
            if (pAutoSave)
                Save(CataloguesIndexFilePath, out errorText);

            return GetIndexByName(pNewName);
        }



        public int Update(string pName, string pDescription = null, int? pAddonCount = null,
            DateTime? pLastUpdate = null, string pVersion = null, bool pAutoSave = true)
        {
            if (string.IsNullOrEmpty(pName = pName?.Trim()))
                return -1;

            int index = GetIndexByName(pName);

            bool newCatalogue = (index < 0);

            CatalogueInfo updatedCatalogueInfo = newCatalogue
                    ? new CatalogueInfo() {Name = pName}
                    : (CatalogueInfo)Catalogues[index].Clone();
            bool needsToSave = false;
            if (!string.IsNullOrEmpty(pDescription = pDescription?.Trim()))
            {
                if (newCatalogue || (pDescription != updatedCatalogueInfo.Description))
                {
                    updatedCatalogueInfo.Description = pDescription;
                    needsToSave = true;
                }
            }

            if (pAddonCount.HasValue && (newCatalogue || pAddonCount.Value != updatedCatalogueInfo.AddonCount))
            {
                updatedCatalogueInfo.AddonCount = pAddonCount.Value;
                needsToSave = true;
            }

            if (pLastUpdate.HasValue && (newCatalogue || pLastUpdate.Value != updatedCatalogueInfo.LastUpdateDateTime))
            {
                updatedCatalogueInfo.LastUpdateDateTime = pLastUpdate.Value;
                needsToSave = true;
            }

            if(!string.IsNullOrEmpty(pVersion = pVersion?.Trim()) && (newCatalogue || (pVersion != updatedCatalogueInfo.Version)))
            {
                updatedCatalogueInfo.Version = pVersion;
                needsToSave = true;
            }


            if (!needsToSave)
                return index;

            if (newCatalogue)
                Catalogues.Add(updatedCatalogueInfo);
            else
                Catalogues[index] = updatedCatalogueInfo;

            List<CatalogueInfo> catalogues = Catalogues.OrderBy(o => o.Name).ToList();
            Catalogues = catalogues;

            string errorText;
            if (pAutoSave)
                Save(CataloguesIndexFilePath, out errorText);

            return GetIndexByName(pName);
        }


        public bool Delete(string pName, bool pAutoSave = true)
        {
            int index = GetIndexByName(pName);
            if (index < 0)
                return false;

            Catalogues.RemoveAt(index);

            string errorText;
            if (pAutoSave)
                Save(CataloguesIndexFilePath, out errorText);
            return true;
        }


        // -------------------------------------------------------------------------------------------------


        public static CataloguesIndex Initialize(MoviestormPaths pMoviestormPaths, out string pErrorText)
        {
            pErrorText = null;

            List<string> catalogueFiles = Directory.EnumerateFiles(Utils.GetExecutableDirectory(), "*.scat").ToList();
            if ((catalogueFiles == null) || (catalogueFiles.Count == 0))
                return InitializeNoCatalogues(pMoviestormPaths, out pErrorText);

            int defaultIndex = -1;
            int index = 0;

            List<CatalogueInfo> catalogues = new List<CatalogueInfo>();
            foreach (string file in catalogueFiles)
            {
                CatalogueInfo catalogue = new CatalogueInfo()
                {
                    Name = Path.GetFileNameWithoutExtension(file)
                };
                string errorText;
                AddonPackageSet packageSet = AddonPackageSet.Load(out errorText, file);
                catalogue.Description = packageSet?.Description;

                if ((catalogue.FilePath.ToLower() == AddonPackageSet.DefaultAddonPackageSetFileName.ToLower()) ||
                    (catalogueFiles.Count == 1))
                {
                    if (catalogue.Description == null)
                        catalogue.Description = "Default catalogue";
                    defaultIndex = index;
                }

                catalogue.LastUpdateDateTime = packageSet.LastUpdate;
                catalogue.AddonCount = packageSet?.Addons.Count ?? 0;
                catalogue.Version = packageSet.CatalogueVersion;

                catalogues.Add(catalogue);
                index++;
            }

            CataloguesIndex cataloguesIndex = new CataloguesIndex();
            cataloguesIndex.Catalogues = catalogues.OrderBy(o => o.FilePath).ToList();

            cataloguesIndex.DefaultAddonDatabase =
                (defaultIndex < 0)
                    ? cataloguesIndex.Catalogues[0].Name
                    : cataloguesIndex.Catalogues[defaultIndex].Name;

            cataloguesIndex.Save(CataloguesIndexFilePath, out pErrorText);
            return cataloguesIndex;
        }



        private static CataloguesIndex InitializeNoCatalogues(MoviestormPaths pMoviestormPaths, out string pErrorText)
        {
            CataloguesIndex cataloguesIndex = new CataloguesIndex();
            cataloguesIndex.Catalogues = new List<CatalogueInfo>();

            AddonPackageSet packageSet = new AddonPackageSet(pMoviestormPaths, null)
            {
                Description = "Default catalogue"
            };
            packageSet.Save(out pErrorText, cataloguesIndex.DefaultAddonDatabaseFilename);
            CatalogueInfo catalogue = new CatalogueInfo()
            {
                Name = cataloguesIndex.DefaultAddonDatabase,
                Description = "Default catalogue",
                AddonCount = 0,
                LastUpdateDateTime = packageSet.LastUpdate,
                Version = packageSet.CatalogueVersion
            };

            cataloguesIndex.Catalogues.Add(catalogue);
            cataloguesIndex.Save(CataloguesIndexFilePath, out pErrorText);

            return cataloguesIndex;
        }


        // -----------------------------------------------------------------------------------------------


        /// <summary>
        /// Loads catalogues info from file
        /// </summary>
        /// <param name="pErrorText">Text of error, if any</param>
        /// <returns>Catalogues info loaded (or null, if failed)</returns>
        public static CataloguesIndex Load(out string pErrorText)
        {
            pErrorText = null;

            if (!File.Exists(CataloguesIndexFilePath))
            {
                return null;
            }

            CataloguesIndex cataloguesIndex = new CataloguesIndex();

            try
            {
                XmlSerializer serializer = new XmlSerializer(cataloguesIndex.GetType());
                using (StreamReader reader = new StreamReader(CataloguesIndexFilePath))
                {
                    cataloguesIndex = (CataloguesIndex)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                pErrorText = exception.Message;
                if (exception.InnerException != null)
                    pErrorText += $" ({exception.InnerException.Message})";
                cataloguesIndex = null;
            }
            return cataloguesIndex;
        }

    }




    [Serializable]
    public sealed class CatalogueInfo : ICloneable
    {
        public string FilePath => _name == null ? null : _name + AddonPackageSet.AddonPackageSetFileExtension;

        public string Name
        {
            get { return _name; }
            set
            {
                string name = value?.Trim();
                if (string.IsNullOrEmpty(name))
                    name = null;
                else
                {
                    name = Path.GetFileNameWithoutExtension(name);
                    if (string.IsNullOrEmpty(name.Trim()))
                        name = null;
                }
                _name = name;
            }
        }
        private string _name;

        public string Description { get; set; }

        public string Version { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }

        public int AddonCount { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
