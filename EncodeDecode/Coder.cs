using System;
using System.IO;
using System.Linq;

namespace EncodeDecode
{
    public class Coder
    {
        /// <summary>
        /// Decode to file
        /// </summary>
        /// <param name="sourceString">Encoded data (base64)</param>
        /// <param name="destinationFilePath">Output file</param>
        public static void DecodeToFile(string sourceString, string destinationFilePath)
        {
            byte[] filebytes = Convert.FromBase64String(sourceString);
            FileStream fs = new FileStream(destinationFilePath,
                FileMode.CreateNew,
                FileAccess.Write,
                FileShare.None);
            fs.Write(filebytes, 0, filebytes.Length);
            fs.Close();
        }
        
        /// <summary>
        /// Encode the file data onto base64 
        /// </summary>
        /// <param name="sourceFilePath">File path</param>
        /// <returns>Encoded string</returns>
        public static string EncodeFile(string sourceFilePath)
        {
            string encodedData;

            try
            {
                if (File.Exists(sourceFilePath))
                {
                    FileStream fs = new FileStream(sourceFilePath,
                        FileMode.Open,
                        FileAccess.Read);
                    byte[] filebytes = new byte[fs.Length];
                    fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                    encodedData =
                        Convert.ToBase64String(filebytes,
                            Base64FormattingOptions.InsertLineBreaks);
                }
                else
                {
                    encodedData = "File not found";
                }
            }
            catch (Exception ex)
            {
                encodedData = ex.Message;
            }
            return encodedData;
        }
    }
}
