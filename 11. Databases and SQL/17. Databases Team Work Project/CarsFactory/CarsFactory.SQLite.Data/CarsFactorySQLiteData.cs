namespace CarsFactory.SQLite.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;

    public class CarsFactorySQLiteData
    {
        private const string StringConnection = @"Data Source=../../../SQLite Database/CarsFactoryDB.db;Version=3;";

        private SQLiteConnection dbCon;

        public static void Test()
        {
            CarsFactorySQLiteData productsRejection = new CarsFactorySQLiteData();

            try
            {
                productsRejection.ConnectToDB();

                var productsRejectionAsList = productsRejection.GetData();
            }
            finally
            {
                productsRejection.DisconnectFromDB();
            }
        }

        public void ConnectToDB()
        {
            dbCon = new SQLiteConnection(StringConnection);
            dbCon.Open();
        }

        public void DisconnectFromDB()
        {
            if (dbCon != null)
            {
                dbCon.Close();
            }
        }

        public IList<ProductRejection> GetData()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM CarsRejection;", dbCon);
            SQLiteDataReader reader = command.ExecuteReader();
            IList<ProductRejection> productsRejection = new List<ProductRejection>();

            using (reader)
            {
                while (reader.Read())
                {
                    var productRejection = new ProductRejection()
                    {
                        ID = (long)reader["ID"],
                        Model = (string)reader["Model"],
                        RejectionCount = (long)reader["RejectionCount"]
                    };

                    productsRejection.Add(productRejection);
                }
            }

            return productsRejection;
        }
    }
}