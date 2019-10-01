using System;
using System.Collections.Generic;
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




    }
}
