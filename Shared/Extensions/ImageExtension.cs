using System;
using System.IO;

namespace Ensco.Irma.Extensions
{
    public static class ImageDocumentExtension
    {
        public static byte[] Get(this string imageFilePath)
        {
            var img = File.ReadAllBytes(imageFilePath);
            return img;
        } 

        public static bool Save(this byte[] bytes, string fullfileName)
        {
            if (string.IsNullOrEmpty(fullfileName))
            {
                return false;
            }

            File.WriteAllBytes(fullfileName, bytes); 

            return true;    
        }
         

    }
}
