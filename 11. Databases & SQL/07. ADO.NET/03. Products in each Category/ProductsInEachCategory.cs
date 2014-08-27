namespace _03.Products_in_each_Category
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Text;

    public class ProductsInEachCategory
    {
        public static void Main()
        {
            // NOTE: please edit connection string in App.config to fit your server address.
            string connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // NOTE: Remove TOP 4 in CROSS APPLY to see all products in category
            // this is put just for better appearance
            SqlCommand sqlCommand = new SqlCommand(
                                        @"SELECT c.CategoryName, p.ProductName
                                        FROM Categories c
                                        CROSS APPLY (
                                            SELECT TOP 4 *
                                            FROM Products p
                                            WHERE c.CategoryID = p.CategoryID
                                        ) p
                                        ORDER BY c.CategoryName", 
                                        sqlConnection);
            var categoryProducts = new Dictionary<string, ISet<string>>();
            sqlConnection.Open();
            using (sqlConnection)
            {
                using (SqlDataReader sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        var categoryName = sqlReader["CategoryName"].ToString();
                        var productName = sqlReader["ProductName"].ToString();
                        if (!categoryProducts.ContainsKey(categoryName))
                        {
                            categoryProducts[categoryName] = new HashSet<string>();
                        }

                        categoryProducts[categoryName].Add(productName);
                    }
                }

                PrintResults(categoryProducts);
            }
        }

        private static void PrintResults(Dictionary<string, ISet<string>> categoryProducts)
        {
            var result = new StringBuilder();
            foreach (var category in categoryProducts)
            {
                result.AppendFormat("Category {0} - {1}", category.Key, string.Join(", ", category.Value));
                result.AppendLine();
            }

            Console.WriteLine(result);
        }
    }
}
