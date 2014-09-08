using System;
using System.Data.SqlClient;
using System.Globalization;

class WorkingWithDates
{
    const string CONNECTION_STRING = 
        "Server=.\\SQLEXPRESS; database=Northwind; Integrated Security=SSPI";
    private static SqlConnection dbCon;

    static void Main()
    {
        WorkingWithDates datesExample = new WorkingWithDates();
        datesExample.ConnectToSqlServer();
		try
		{
			datesExample.DropMessagesTable();
			datesExample.CreateMessagesTable();
			datesExample.AddMessage("Test message 1", DateTime.Now);
			datesExample.AddMessage("Test message 2", DateTime.Now);
			datesExample.AddMessage("Test message 3", DateTime.Now);
			CultureInfo cultureBulgaria = new CultureInfo("bg-BG");
			datesExample.DisplayAllMessages(cultureBulgaria, "dd-MMM-yyyy HH:mm:ss");
			datesExample.DropMessagesTable();
		}
		finally
		{
			datesExample.DisconnectFromSqlServer();
		}
    }

    public void ConnectToSqlServer()
    {
        dbCon = new SqlConnection(CONNECTION_STRING);
        dbCon.Open();
    }

    public void CreateMessagesTable()
    {
        SqlCommand cmdCreateMsgTable = new SqlCommand(
            @"CREATE TABLE Messages
			(
				MsgId int identity not null primary key,
				MsgText nvarchar(1000),
				MsgDate datetime
			)",
            dbCon
        );
        cmdCreateMsgTable.ExecuteNonQuery();
	
		Console.WriteLine("Created the Messages table.");
	}

    public void AddMessage(string msgText, DateTime msgDate)
    {
		SqlCommand cmdInsertMsg = new SqlCommand(
			"INSERT INTO Messages(MsgText, MsgDate) " +
			"VALUES (@MsgText, @MsgDate)", dbCon);
		cmdInsertMsg.Parameters.AddWithValue("@MsgText", msgText);
		cmdInsertMsg.Parameters.AddWithValue("@MsgDate", msgDate);
		cmdInsertMsg.ExecuteNonQuery();

        Console.WriteLine("Inserted record in Messages table.");
    }

    public void DisplayAllMessages(CultureInfo cultureInfo, string format)
    {
        SqlCommand cmdSelectMsgs = new SqlCommand(
            "SELECT MsgText, MsgDate FROM Messages", dbCon);
        SqlDataReader reader = cmdSelectMsgs.ExecuteReader();
        using (reader)
        {
            while (reader.Read())
            {
                string msgText = (string)reader["MsgText"];
                DateTime msgDate = (DateTime)reader["MsgDate"];
                string msgDateFormatted = msgDate.ToString(format, cultureInfo);
                Console.WriteLine("{0} - {1}", msgDateFormatted, msgText);
            }
        }
    }

    public void DropMessagesTable()
    {
        SqlCommand cmdCreateMsgTable = new SqlCommand(
            @"IF OBJECT_ID('Messages') IS NOT NULL
			DROP TABLE Messages",
            dbCon);
        cmdCreateMsgTable.ExecuteNonQuery();

		Console.WriteLine("Dropped the Messages table.");
	}

    public void DisconnectFromSqlServer()
    {
        dbCon.Close();
    }
}
