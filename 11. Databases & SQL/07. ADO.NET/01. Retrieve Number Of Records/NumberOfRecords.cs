namespace _01.Retrieve_Number_Of_Records
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class NumberOfRecords
    {
        // NOTE: please edit connection string in App.config to fit your server address.
        public static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(CategoryId) FROM Categories", sqlConnection);
                int countOfCategories = (int)sqlCommand.ExecuteScalar();
                Console.WriteLine("Count of all Categories is: {0}", countOfCategories);
            }
        }
    }
}
