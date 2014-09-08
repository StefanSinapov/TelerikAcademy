namespace _08.Products_Containing_String
{
    using System.Configuration;
    using System.Data.SqlClient;
    using System;    

    class ProductsContainingString
    {
        public static void Main()
        {
            // NOTE: please edit connection string in App.config to fit your server address.

            string searchWord = Console.ReadLine();
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (sqlConnection)
            {
                var sqlCommand = new SqlCommand(
                                @"SELECT ProductName FROM Products WHERE CHARINDEX(@searchWord, ProductName) > 0", 
                                sqlConnection);
                sqlCommand.Parameters.AddWithValue("@searchWord", searchWord);
                using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        var name = (string)sqlReader["ProductName"];

                        Console.WriteLine("Product: {0}", name);
                    }
                }
            }
        }
    }
}
