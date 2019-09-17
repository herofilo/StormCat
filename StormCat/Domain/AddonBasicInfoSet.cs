using System.Collections.Generic;
using System.Linq;
using MSAddonLib.Domain.Addon;

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


        public AddonBasicInfoSet(List<AddonPackage> pAddons)
        {
            List<AddonBasicInfo>  addons = new List<AddonBasicInfo>();
            if (pAddons == null)
                return;
            foreach(AddonPackage addon in pAddons) 
                addons.Add(new AddonBasicInfo(addon));

            Addons = addons.OrderBy(o => o.Name).ToList();
        }


    }
}
