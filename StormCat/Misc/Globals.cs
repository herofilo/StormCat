using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Drawing;
using MSAddonLib.Util;
using Path = System.IO.Path;

namespace StormCat.Misc
{
    public  static class Globals
    {

        public const string HelpFilenameBase = @"StormCat.chm";

        public static string HelpFilename
        {
            get
            {
                if (_helpFileName == null)
                    _helpFileName = Path.Combine(Utils.GetExecutableDirectory(), HelpFilenameBase);
                return _helpFileName;
            }
        }

        public static string HelpFileUri
        {
            get { return $"file://{HelpFilename}"; }
        }

        private static string _helpFileName = null;


    }
}
