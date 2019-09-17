using System;
using System.IO;
using System.Xml.Serialization;
using MSAddonLib.Persistence.AddonDB;
using MSAddonLib.Util;

namespace StormCat.Configuration
{
    public class ApplicationConfiguration : ConfigurationFileBase
    {
        public string MoviestormInstallationPath { get; set; }

        public string MoviestormUserDataPath { get; set; }

        public static string ConfigurationFilePath => Path.Combine(Utils.GetExecutableDirectory(), "StormCat.cfg");

        public static string OldConfigurarionFilePath => Path.Combine(Utils.GetExecutableDirectory(), "MSAddonChecker.cfg");


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

            string configurationFilename = ConfigurationFilePath;
            if (File.Exists(OldConfigurarionFilePath))
            {
                try
                {
                    File.Move(OldConfigurarionFilePath, ConfigurationFilePath);
                }
                catch (Exception exception)
                {
                    configurationFilename = OldConfigurarionFilePath;
                }
            }
            

            if (!File.Exists(configurationFilename))
            {
                return null;
            }

            ApplicationConfiguration configurationInfo = new ApplicationConfiguration();

            try
            {
                XmlSerializer serializer = new XmlSerializer(configurationInfo.GetType());
                using (StreamReader reader = new StreamReader(configurationFilename))
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
