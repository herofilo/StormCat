using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Xml.Serialization;
using MSAddonLib.Domain.Addon;
using MSAddonLib.Persistence.AddonDB;
using MSAddonLib.Util;
using StormCat.Configuration;

namespace StormCat.Domain
{
    public class AddonPackageSetOperator
    {

        public AddonPackageSet AddonPackageSet { get; private set; }


        public AddonPackageSetOperator(AddonPackageSet pAddonPackageSet)
        {
            AddonPackageSet = pAddonPackageSet;
        }


        #region CopyAndPasteRegion

        // ----------------------------------------------------------------------------------------------------------------------------------------------------

        public List<AddonPackage> GetAddonSubSet(List<string> pQualifiedNames)
        {
            if (AddonPackageSet == null)
                return null;

            List<AddonPackage> subSet = new List<AddonPackage>();
            if ((AddonPackageSet.Addons == null) || (AddonPackageSet.Addons.Count == 0))
                return subSet;

            if ((pQualifiedNames != null) && (pQualifiedNames.Count > 0))
            {
                List<string> names = new List<string>();
                foreach (string name in pQualifiedNames)
                {
                    string nameLower = name.Trim().ToLower();
                    if (!string.IsNullOrEmpty(nameLower))
                        names.Add(nameLower);
                }
                foreach (AddonPackage addon in AddonPackageSet.Addons)
                {
                    if (names.Contains(addon.QualifiedName.ToLower()))
                        subSet.Add(addon);
                }
            }
            return subSet;
        }



        public string GetAddonSubSetText(List<string> pQualifiedNames)
        {

            List<AddonPackage> subSet = GetAddonSubSet(pQualifiedNames);
            if (subSet == null)
                return null;


            StringBuilder serializerStringBuilder = new StringBuilder();
            try
            {
                XmlSerializer serializer = new XmlSerializer(subSet.GetType());
                using (StringWriter writer = new StringWriter(serializerStringBuilder))
                {
                    serializer.Serialize(writer, subSet);
                    writer.Close();
                }
            }
            catch (Exception exception)
            {

                return null;
            }

            return serializerStringBuilder.ToString();
        }




        public int AppendAddonSubSet(List<AddonPackage> pSubSet)
        {
            if ((pSubSet == null) || (pSubSet.Count == 0))
                return 0;

            if (AddonPackageSet == null)
                return -1;

            if ((AddonPackageSet.Addons == null) || (AddonPackageSet.Addons.Count == 0))
            {
                AddonPackageSet.Addons = pSubSet;
                return pSubSet.Count;
            }

            int count = 0;
            foreach (AddonPackage addon in pSubSet)
            {
                if (AddonPackageSet.Append(addon, false))
                    count++;
            }

            return count;
        }



        public int AppendAddonSubSet(string pText)
        {
            if (string.IsNullOrEmpty(pText = pText?.Trim()))
                return 0;

            string errorText;
            List<AddonPackage> subSet = DeserializeAddonPackageList(pText, out errorText);

            return (subSet == null) ? -1 : AppendAddonSubSet(subSet);
        }



        public static List<AddonPackage> DeserializeAddonPackageList(string pText, out string pErrorText)
        {
            pErrorText = null;
            if (string.IsNullOrEmpty(pText = pText?.Trim()))
            {
                pErrorText = "Text is null";
                return null;
            }

            List<AddonPackage> subSet = new List<AddonPackage>();

            try
            {
                XmlSerializer serializer = new XmlSerializer(subSet.GetType());
                using (StringReader reader = new StringReader(pText))
                {
                    subSet = (List<AddonPackage>)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                pErrorText = Utils.GetExceptionExtendedMessage(exception);
                return null;
            }

            return subSet;
        }

        #endregion CopyAndPasteRegion


        // ---------------------------------------------------------------------------------------------------------------------------

        public static List<CatalogueContentComparisionItem> CompareCataloguesContents(AddonPackageSet pPackageSet0, AddonPackageSet pPackageSet1)
        {
            List<string> addonsCatalogue0 = GetAddonsInPackageSorted(pPackageSet0);
            List<string> addonsCatalogue1 = GetAddonsInPackageSorted(pPackageSet1);

            List<CatalogueContentComparisionItem> comparisionItems = new List<CatalogueContentComparisionItem>();

            if (addonsCatalogue0.Count == 0)
            {
                foreach (string addon1 in addonsCatalogue1)
                    comparisionItems.Add(new CatalogueContentComparisionItem() { AddonCatalogue1 = addon1 });

                return comparisionItems;
            }
            if (addonsCatalogue1.Count == 0)
            {
                foreach (string addon0 in addonsCatalogue0)
                    comparisionItems.Add(new CatalogueContentComparisionItem() { AddonCatalogue0 = addon0 });

                return comparisionItems;
            }

            do
            {
                string addon0 = addonsCatalogue0.Count > 0 ? addonsCatalogue0[0] : "";
                string addon1 = addonsCatalogue1.Count > 0 ? addonsCatalogue1[0] : "";
                if (addon0 == "")
                {
                    if (addon1 == "")
                        break;          // it shoudn't happen
                    foreach(string addon in addonsCatalogue1) 
                        comparisionItems.Add(new CatalogueContentComparisionItem() {AddonCatalogue1 = addon});
                    break;
                }
                if (addon1 == "")
                {
                    foreach (string addon in addonsCatalogue0)
                        comparisionItems.Add(new CatalogueContentComparisionItem() { AddonCatalogue0 = addon });
                    break;
                }

                int stringCompare = string.Compare(addon0, addon1, StringComparison.InvariantCulture);
                if (stringCompare == 0)
                {
                    comparisionItems.Add(new CatalogueContentComparisionItem() { AddonCatalogue0 = addon0, AddonCatalogue1 = addon1});
                    addonsCatalogue0.RemoveAt(0);
                    addonsCatalogue1.RemoveAt(0);
                    continue;
                }

                if (stringCompare < 0)
                {
                    comparisionItems.Add(new CatalogueContentComparisionItem() { AddonCatalogue0 = addon0 });
                    addonsCatalogue0.RemoveAt(0);
                    continue;
                }

                comparisionItems.Add(new CatalogueContentComparisionItem() { AddonCatalogue1 = addon1 });
                addonsCatalogue1.RemoveAt(0);


            } while ((addonsCatalogue0.Count > 0) || (addonsCatalogue1.Count > 0));

            return comparisionItems;
        }


        private static List<string> GetAddonsInPackageSorted(AddonPackageSet pPackageSet)
        {
            List<string> addons = new List<string>();
            if ((pPackageSet.Addons?.Count ?? 0) == 0)
                return addons;

            foreach (AddonPackage addon in pPackageSet.Addons)
            {
                addons.Add($"{addon.Name} [{addon.Publisher}]");
            }

            addons.Sort();

            // Removes duplicated...

            List<string> notDups = new List<string>();
            string last = "xxx";
            foreach (string item in addons)
            {
                if (item == last)
                    continue;
                notDups.Add(item);
                last = item;
            }

            return notDups;
        }





    }


    public sealed class CatalogueContentComparisionItem
    {
        public string AddonCatalogue0 { get; set; }

        public string AddonCatalogue1 { get; set; }
    }






}
