namespace CohesionAndCoupling.Utility
{
    using System;

    public static class FileUtilites
    {
        public static string GetFileExtension(string fileName)
        {
            string fileExtension = GetFileNameAndExtension(fileName)[1];
            return fileExtension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            string fileNameWithoutExt = GetFileNameAndExtension(fileName)[0];
            return fileNameWithoutExt;
        }

        private static string[] GetFileNameAndExtension(string fileName)
        {
            string[] result = new string[2];
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                result[0] = fileName;
                result[1] = string.Empty;
            }
            else
            {
                result[1] = fileName.Substring(indexOfLastDot + 1);
                result[0] = fileName.Substring(0, indexOfLastDot);
            }

            return result;
        }
    }
}
