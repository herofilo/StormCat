using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StormCat.Persistence
{
    public enum CataloguesIndexOperation
    {
        Null,
        NewCatalogue,
        RenameCatalogue,
        EditDescription,
        DeleteCatalogue,
        CopyCatalogue,
        LoadCatalogue,
        SaveCatalogue,
        SetDefaultCatalogue,
        RefreshIndex
    }
}
