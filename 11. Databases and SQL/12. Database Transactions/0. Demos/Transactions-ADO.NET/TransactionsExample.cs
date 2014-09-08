using System;
using System.Data;
using System.Data.SqlClient;

class TransactionsExample
{
    private const string CONNECTION_STRING = "Server=.\\SQLEXPRESS;" +
        " Database=Northwind; Integrated Security=true";

    static void Main()
    {
        SqlConnection dbCon = new SqlConnection(CONNECTION_STRING);
        dbCon.Open();
        using (dbCon)
        {
            SqlTransaction trans =
                dbCon.BeginTransaction(IsolationLevel.ReadCommitted);
            Console.WriteLine("Transaction started.");

            SqlCommand cmd = dbCon.CreateCommand();
            cmd.Transaction = trans;
            try
            {
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

                trans.Commit();
                Console.WriteLine("Transaction comitted.");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception occured: {0}", e.Message);
                trans.Rollback();
                Console.WriteLine("Transaction cancelled.");
            }
        }
    }
}
