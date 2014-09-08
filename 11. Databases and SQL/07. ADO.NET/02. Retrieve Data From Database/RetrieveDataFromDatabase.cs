namespace _02.Retrieve_Data_From_Database
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class RetrieveDataFromDatabase
    {
        public static void Main()
        {
            // NOTE: please edit connection string in App.config to fit your server address.
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                var sqlCommand = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", sqlConnection);

                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                using (sqlReader)
                {
                    while (sqlReader.Read())
                    {
                        var name = (string)sqlReader["CategoryName"];
                        var description = (string)sqlReader["Description"];

                        Console.WriteLine("Category {0} - {1}", name, description);
                    }
                }
            }
        }
    }
}
