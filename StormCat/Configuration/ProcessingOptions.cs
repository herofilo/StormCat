using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MSAddonLib.Domain;
using MSAddonLib.Util;

namespace MSAddonChecker.Configuration
{
    public class ProcessingOptions : ConfigurationFileBase
    {

        public ProcessingFlags ProcessingFlags { get; set; } = ProcessingFlags.None;

        public static string ConfigurationFilePath => Path.Combine(Utils.GetExecutableDirectory(), "ProcessingOptions.cfg");

        // ----------------------------------------------------------------------------

        /// <summary>
        /// Loads configuration from file
        /// </summary>
        /// <param name="pErrorText">Text of error, if any</param>
        /// <returns>Application configuration loaded (or null, if failed)</returns>
        public static ProcessingOptions Load(out string pErrorText)
        {
            pErrorText = null;

            ProcessingOptions processingOptions = new ProcessingOptions();

            if (!File.Exists(ConfigurationFilePath))
            {
                return null;
            }


            try
            {
                XmlSerializer serializer = new XmlSerializer(processingOptions.GetType());
                using (StreamReader reader = new StreamReader(ConfigurationFilePath))
                {
                    processingOptions = (ProcessingOptions)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception exception)
            {
                pErrorText = exception.Message;
                if (exception.InnerException != null)
                    pErrorText += $" ({exception.InnerException.Message})";
                processingOptions = null;
            }
            return processingOptions;
        }

    }
}
