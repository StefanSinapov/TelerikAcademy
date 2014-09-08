using System;
using System.Transactions;
using System.Data.SqlClient;

class TransactionScopeExample
{
    private const string CONNECTION_STRING = "Server=.\\SQLEXPRESS; " +
        "Database=Northwind; Integrated Security=true";

    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(CONNECTION_STRING);
        try
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                dbCon.Open();
                try
                {
                    Console.WriteLine("Transaction started.");

                    SqlCommand cmd = dbCon.CreateCommand();

                    cmd.CommandText =
                        "INSERT INTO Shippers(CompanyName, Phone) " +
                        "VALUES ('New record', '111-111-1111')";
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted a new record.");

                    // This insert will fail (CompanyName cannot be null)
                    cmd.CommandText =
                        "INSERT INTO Shippers(CompanyName, Phone) " +
                        "VALUES (null, '123-456-7890')";
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted a new record.");

                    transaction.Complete();
                    Console.WriteLine("Transaction comitted.");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Exception occured: {0}", e.Message);
                    Console.WriteLine("Transaction cancelled.");
                }
            }

        }
        finally
        {
            dbCon.Close();
        }
    }
}
