namespace _05.Retrieve_Images_Of_Categories
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Globalization;
    using System.IO;

    public class RetrieveImagesOfCategories
    {
        static void Main()
        {
            // NOTE: please edit connection string in App.config to fit your server address.
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var dbConnection = new SqlConnection(connectionString);
            var sqlCommand = new SqlCommand(
                "SELECT CategoryId, Picture " +
                "FROM Categories",
                dbConnection);
            dbConnection.Open();
            using (dbConnection)
            {
                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var imageId = (int)dataReader["CategoryId"];
                        var fileBinaryData = (byte[])dataReader["Picture"];

                        ByteArrayToImage(imageId.ToString(CultureInfo.InvariantCulture), fileBinaryData, ".jpg");
                        Console.WriteLine("Image {0} is saved in ./bin/Debug folder.", imageId);
                    }
                }
            }
        }

        public static void ByteArrayToImage(string fileName, byte[] imageBinaryData, string format)
        {
            var memoryStream = new MemoryStream(imageBinaryData, 78, imageBinaryData.Length - 78);

            using (memoryStream)
            {
                using (Image image = Image.FromStream(memoryStream))
                {
                    image.Save(fileName + format);
                }
            }
        }

    }
}
