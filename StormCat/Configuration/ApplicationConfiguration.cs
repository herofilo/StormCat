using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Xml.Serialization;
using Microsoft.SqlServer.Server;
using MSAddonLib.Util;

namespace MSAddonChecker.Configuration
{
    public class ApplicationConfiguration : ConfigurationFileBase
    {
        public string MoviestormInstallationPath { get; set; }

        public string MoviestormUserDataPath { get; set; }


        public static string ConfigurationFilePath => Path.Combine(Utils.GetExecutableDirectory(), "MSAddonChecker.cfg");


        // ----------------------------------------------------------------------------

        public ApplicationConfiguration()
        {

        }

        public ApplicationConfiguration(string pMoviestormInstallationPath, string pMoviestormUserDataPath)
        {
            MoviestormInstallationPath = pMoviestormInstallationPath;
            MoviestormUserDataPath = pMoviestormUserDataPath;
        }

        // ----------------------------------------------------------------------------

        /// <summary>
        /// Loads configuration from file
        /// </summary>
        /// <param name="pErrorText">Text of error, if any</param>
        /// <returns>Application configuration loaded (or null, if failed)</returns>
        public static ApplicationConfiguration Load(out string pErrorText)
        {
            pErrorText = null;
            if (!File.Exists(ConfigurationFilePath))
            {
                return null;
            }

            ApplicationConfiguration configurationInfo = new ApplicationConfiguration();

            try
            {
                XmlSerializer serializer = new XmlSerializer(configurationInfo.GetType());
                using (StreamReader reader = new StreamReader(ConfigurationFilePath))
                {
                    configurationInfo = (ApplicationConfiguration)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                pErrorText = exception.Message;
                if (exception.InnerException != null)
                    pErrorText += $" ({exception.InnerException.Message})";
                configurationInfo = null;
            }
            return configurationInfo;
        }

    }
}
