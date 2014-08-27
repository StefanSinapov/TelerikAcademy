namespace _04.Insert_new_record
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    class InsertNewRecordToDatabase
    {
        static void Main()
        {
            // NOTE: please edit connection string in App.config to fit your server address.
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connectionString);

            var productName = "Biscuit Zakuska";
            var supplierId = 5;
            var categoryId = 7;
            var quantityPerUnit = "200 g tins";
            var unitPrice = 1.89d;
            var unitsInStock = 1000;
            var unitsInOrder = 500;
            var reorderLevel = 30;
            var discontinued = 0;

            SqlCommand sqlCommand =
                new SqlCommand(@"INSERT INTO Products
                             VALUES (@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, 
                                     @unitsInStock, @unitsInOrder, @reorderLevel, @discontinued)", dbConnection);

            sqlCommand.Parameters.AddWithValue("@productName", productName);
            sqlCommand.Parameters.AddWithValue("@supplierId", supplierId);
            sqlCommand.Parameters.AddWithValue("@categoryId", categoryId);
            sqlCommand.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            sqlCommand.Parameters.AddWithValue("@unitPrice", unitPrice);
            sqlCommand.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            sqlCommand.Parameters.AddWithValue("@unitsInOrder", unitsInOrder);
            sqlCommand.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            sqlCommand.Parameters.AddWithValue("@discontinued", discontinued);

            dbConnection.Open();
            using (dbConnection)
            {
                var result = sqlCommand.ExecuteNonQuery();
                Console.WriteLine("{0} products added!", result);
            }
        }
    }
}
