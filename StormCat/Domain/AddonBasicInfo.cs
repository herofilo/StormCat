using MSAddonLib.Domain.Addon;

namespace StormCat.Domain
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

        public string Description { get; private set; }

        public int? BodyPartCount { get; private set; }

        public int? DecalCount { get; private set; }

        public int? PropCount { get; private set; }

        public int? AnimationCount { get; private set; }

        public int? VerbCount { get; private set; }

        public int? MaterialCount { get; private set; }

        public int? SoundCount { get; private set; }

        public int? FilterCount { get; private set; }

        public int? SpecialEffectCount { get; private set; }

        public int? SkyTextureCount { get; private set; }

        public int? StockCount { get; private set; }

        public int? DemoMovieCount { get; private set; }

        public string Location { get; private set; }
        

        public AddonBasicInfo(AddonPackage pPackage)
        {
            Name = pPackage.Name;
            Publisher = pPackage.Publisher;
            Installed = pPackage.AddonFormat == AddonPackageFormat.InstalledFolder;
            Free = pPackage.Free;
            Recompilable = pPackage.Recompilable;
            Description = pPackage.Description;

            BodyPartCount = GetCountValue(pPackage.AssetSummary?.Bodyparts);
            DecalCount = GetCountValue(pPackage.AssetSummary?.Decals);
            PropCount = GetCountValue(pPackage.AssetSummary?.Props);
            AnimationCount = GetCountValue(pPackage.AssetSummary?.Animations);
            VerbCount = GetCountValue(pPackage.AssetSummary?.Verbs);
            SoundCount = GetCountValue(pPackage.AssetSummary?.Sounds);
            FilterCount = GetCountValue(pPackage.AssetSummary?.Filters);
            SpecialEffectCount = GetCountValue(pPackage.AssetSummary?.SpecialEffects);
            MaterialCount = GetCountValue(pPackage.AssetSummary?.Materials);
            SkyTextureCount = GetCountValue(pPackage.AssetSummary?.SkyTextures);
            StockCount = GetCountValue(pPackage.AssetSummary?.Stocks);
            DemoMovieCount = GetCountValue(pPackage.AssetSummary?.StartMovies);

            Location = pPackage.Location;
            if (MoviestormContentPackPath != null)
                ContentPack = Location.ToLower().StartsWith(MoviestormContentPackPath.ToLower());
        }

        private int? GetCountValue(int? pCount)
        {
            if ((pCount == null) || (pCount.Value == 0))
                return null;

            return pCount.Value;
        }
    }
}
