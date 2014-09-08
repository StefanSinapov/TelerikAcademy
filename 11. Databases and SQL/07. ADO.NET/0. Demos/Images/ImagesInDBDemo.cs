using System;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Data;

class ImagesInDBDemo
{
    private const string DB_CONNECTION_STRING =
        @"Data Source=.\SQLEXPRESS; Initial Catalog = Images; Integrated Security = SSPI";
    private const string SOURCE_IMAGE_FILE_NAME =
        @"..\..\logo.gif";
    private const string DEST_IMAGE_FILE_NAME =
        @"..\..\logo-from-db.gif";

    private static byte[] ReadBinaryFile(string fileName)
    {
        FileStream stream = File.OpenRead(fileName);
        using (stream)
        {
            int pos = 0;
            int length = (int)stream.Length;
            byte[] buf = new byte[length];
            while (true)
            {
                int bytesRead = stream.Read(buf, pos, length - pos);
                if (bytesRead == 0)
                {
                    break;
                }
                pos += bytesRead;
            }
			return buf;
		}
    }

    private static void WriteBinaryFile(string fileName,
        byte[] fileContents)
    {
        FileStream stream = File.OpenWrite(fileName);
        using (stream)
        {
            stream.Write(fileContents, 0, fileContents.Length);
        }
    }

    private static string GetImageFormat(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string fileExtenstion = fileInfo.Extension;
        string imageFormat = fileExtenstion.ToLower().Substring(1);
        return imageFormat;
    }

    private static int[] ListImageIdsFromDB()
    {
        SqlConnection dbConn = new SqlConnection(DB_CONNECTION_STRING);
        dbConn.Open();
        using (dbConn)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT ImageId FROM Images", dbConn);
            ArrayList imageIds = new ArrayList();
            SqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    int imageId = (int)reader["ImageId"];
                    imageIds.Add(imageId);
                }
            }

            int[] imageIdArray = (int[])imageIds.
                ToArray(typeof(int));
            return imageIdArray;
        }
    }

    private static void ExtractImageFromDB(
        int imageId, out byte[] image, out string imageFormat)
    {
        SqlConnection dbConn = new SqlConnection(
            DB_CONNECTION_STRING);
        dbConn.Open();
        using (dbConn)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT Image, ImageFormat FROM Images " +
                "WHERE ImageId=@id", dbConn);
            SqlParameter paramId = new SqlParameter(
                "@id", SqlDbType.Int);
            paramId.Value = imageId;
            cmd.Parameters.Add(paramId);
            SqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    image = (byte[])reader["Image"];
                    imageFormat = (string)reader["ImageFormat"];
                }
                else
                {
                    throw new Exception(
                        String.Format("Invalid image ID={0}.", imageId));
                }
            }
        }
    }

    private static void InsertImageToDB(byte[] image,
        string imageFormat)
    {
        SqlConnection dbConn = new SqlConnection(
            DB_CONNECTION_STRING);
        dbConn.Open();
        using (dbConn)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Images ([Image], ImageFormat) " +
                "VALUES (@image, @imageFormat)", dbConn);

            SqlParameter paramImage =
                new SqlParameter("@image", SqlDbType.Image);
            paramImage.Value = image;
            cmd.Parameters.Add(paramImage);

            SqlParameter paramImageFormat =
                new SqlParameter("@imageFormat", SqlDbType.VarChar);
            paramImageFormat.Value = imageFormat;
            cmd.Parameters.Add(paramImageFormat);

            cmd.ExecuteNonQuery();
        }
    }

    private static void DeleteAllImagesFromDB()
    {
        SqlConnection dbConn = new SqlConnection(
            DB_CONNECTION_STRING);
        dbConn.Open();
        using (dbConn)
        {
            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Images", dbConn);
            cmd.ExecuteScalar();
        }
    }

    static void Main()
    {
        DeleteAllImagesFromDB();
        Console.WriteLine("Deleted all images from the DB.");

        byte[] image = ReadBinaryFile(SOURCE_IMAGE_FILE_NAME);
        string imageFormat = GetImageFormat(
            SOURCE_IMAGE_FILE_NAME);
        Console.WriteLine("Loaded image file {0}.",
            SOURCE_IMAGE_FILE_NAME);

        InsertImageToDB(image, imageFormat);
        Console.WriteLine("Inserted an image in the DB.");

        int[] imageIds = ListImageIdsFromDB();
        Console.WriteLine("There are {0} images in the DB.",
            imageIds.Length);

        int firstImageId = imageIds[0];
        byte[] imageFromDB;
        string imageFormatFromDB;
        ExtractImageFromDB(firstImageId,
            out imageFromDB, out imageFormatFromDB);
        Console.WriteLine("Extracted first image from the DB.");

        WriteBinaryFile(DEST_IMAGE_FILE_NAME, imageFromDB);
        Console.WriteLine("Image saved to file {0}.",
            DEST_IMAGE_FILE_NAME);
    }
}
