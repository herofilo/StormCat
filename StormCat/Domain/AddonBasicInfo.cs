using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSAddonLib.Domain.Addon;

namespace MSAddonChecker.Domain
{
    public sealed class AddonBasicInfo
    {
        public static string MoviestormContentPackPath { get; set; }


        public string Name { get; private set; }

        public string Publisher { get; private set; }

        public bool Installed { get; private set; }

        public bool Free { get; private set; }

        public bool Recompilable { get; private set; }

        public bool ContentPack { get; private set; }

        public string Location { get; private set; }



        public AddonBasicInfo(AddonPackage pPackage)
        {
            Name = pPackage.Name;
            Publisher = pPackage.Publisher;
            Installed = pPackage.AddonFormat == AddonPackageFormat.InstalledFolder;
            Free = pPackage.Free;
            Recompilable = pPackage.Recompilable;
            Location = pPackage.Location;
            if (MoviestormContentPackPath != null)
                ContentPack = Location.ToLower().StartsWith(MoviestormContentPackPath.ToLower());
        }
    }
}
