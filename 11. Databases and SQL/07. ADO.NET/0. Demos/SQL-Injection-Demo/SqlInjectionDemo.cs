using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

class SqlInjectionDemo
{
	static void CreateUsers(SqlConnection dbConnection)
	{
		string sqlPopulateUsersTable = @"
			IF OBJECT_ID('Users') IS NULL
			BEGIN
				CREATE Table Users(
				UserName varchar(50) not null primary key,
				PasswordHash varchar(50) not null)
				INSERT INTO Users VALUES('ivaylo', 'Scsrjm19E1l3mN/yuri312vIHKA=')
				INSERT INTO Users VALUES('doncho', 'bryliJE42mBnpbd+CHZKchNacT8=')
				INSERT INTO Users VALUES('niki', 'HZbkIGvqeCrCRsVvWpb/ihxqBs8=')
			END
		";
		SqlCommand cmd = new SqlCommand(sqlPopulateUsersTable, dbConnection);
		cmd.ExecuteNonQuery();
	}

	static string CalcSHA1(string text)
	{
		SHA1 sha1Algorithm = SHA1.Create();
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		byte[] sha1Bytes = sha1Algorithm.ComputeHash(bytes);
		string sha1Hash = Convert.ToBase64String(sha1Bytes);
		return sha1Hash;
	}

	static bool IsPasswordValid(string username, string password,
		SqlConnection dbConnection)
	{
		// This code is intentially designed to have
		// a vulnerablity to SQL injection (unescaped username)!
		string sql =
			"SELECT COUNT(*) FROM Users " +
			"WHERE UserName = '" + username + "' and " +
			"PasswordHash = '" + CalcSHA1(password) + "'";
		Console.WriteLine("Executing SQL command: " + sql);
		SqlCommand cmd = new SqlCommand(sql, dbConnection);
		int matchedUsersCount = (int)cmd.ExecuteScalar();
		bool isPasswordValid = (matchedUsersCount > 0);
		Console.WriteLine("Password valid: " + isPasswordValid);
		return isPasswordValid;
	}

	static string EscapeSQLString(string str)
	{
		return str.Replace("'", "''");
	}

	static void Main()
    {
		SqlConnection dbConnection = new SqlConnection(
			"Server=.\\SQLEXPRESS; Database=TelerikAcademy; Integrated Security=true");
		dbConnection.Open();
		using (dbConnection)
		{
			CreateUsers(dbConnection);

			// Normal invalid login
			IsPasswordValid("peter", "qwerty123", dbConnection);

			// SQL-injected valid login
			IsPasswordValid(" ' or 1=1 --", "qwerty123", dbConnection);
			
			// SQL-injection that creates a new user in the DB
			IsPasswordValid(" ' or 1=1 INSERT INTO Users VALUES('hacker', 'SQL injection!') --", 
				"qwerty123", dbConnection);
		}
    }
}
