using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using MSAddonLib.Domain.Addon;

namespace StormCat.Misc
{
    public sealed class MiscUtils
    {

        public static bool OpenContainingFolder(AddonPackage pAddon, out string pErrorText)
        {
            return OpenContainingFolder(pAddon?.Location, out pErrorText);
        }


        public static bool OpenContainingFolder(string pPath, out string pErrorText)
        {
            pErrorText = null;
            if (string.IsNullOrEmpty(pPath = pPath?.Trim()))
                return false;

            int index = pPath.LastIndexOf("#", StringComparison.InvariantCulture);
            if (index > 0)
                pPath = pPath.Substring(0, index);


            string pathLower = pPath.ToLower();
            bool isFile = (pathLower.EndsWith(".addon") || pathLower.EndsWith(".rar") || pathLower.EndsWith(".zip") ||
                           pathLower.EndsWith(".7z"));

            string arguments = null;
            if (isFile)
            {
                if (!File.Exists(pPath))
                {
                    pErrorText = "Addon file not found in the location registered!";
                    return false;
                }

                // arguments = Path.GetDirectoryName(pPath);
                arguments = "/select, \"" + pPath + "\"";
            }
            else
            {
                if (!Directory.Exists(pPath))
                {
                    pErrorText = "Registered folder containing the addon not found";
                    return false;
                }
                arguments = pPath;
            }

            bool openOk = false;
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = arguments,
                    FileName = "explorer.exe",
                };
                Process.Start(startInfo);
                openOk = true;
            }
            catch
            {
                pErrorText = "An error has occurred while trying to open Windows Explorer";
            }

            return openOk;
        }


}
}
