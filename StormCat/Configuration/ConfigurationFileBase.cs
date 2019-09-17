using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace StormCat.Configuration
{
    public class ConfigurationFileBase
    {
        /// <summary>
        /// Saves configuration file
        /// </summary>
        /// <param name="pFilename">Output file path</param>
        /// <param name="pErrorText">Text of error, if any</param>
        /// <returns>Result of operation</returns>
        public bool Save(string pFilename, out string pErrorText)
        {
            pErrorText = null;
            if (string.IsNullOrEmpty(pFilename = pFilename?.Trim()))
            {
                pErrorText = "Invalid save file specification";
                return false;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (StreamWriter writer = new StreamWriter(pFilename, false, Encoding.UTF8))
                {
                    serializer.Serialize(writer, this);
                    writer.Close();
                }
            }
            catch (Exception exception)
            {
                pErrorText = exception.Message;
                if (exception.InnerException != null)
                    pErrorText += $" ({exception.InnerException.Message})";
                return false;
            }
            return true;

        }


    }
}
