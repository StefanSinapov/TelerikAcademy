using System;
using System.Data.SqlClient;

internal class CommandAndDataReader
{
    private static void Main()
    {
        var dbCon = new SqlConnection("Server=.\\; " +
                                      "Database=TelerikAcademy; Integrated Security=true");
        dbCon.Open();
        using (dbCon)
        {
            var cmdCount = new SqlCommand(
                "SELECT COUNT(*) FROM Employees", dbCon);
            var employeesCount = (int) cmdCount.ExecuteScalar();
            Console.WriteLine("Employees count: {0} ", employeesCount);
            Console.WriteLine();

            Console.WriteLine("The most paid 10 employees:");
            var cmdAllEmployees = new SqlCommand(
                "SELECT TOP 10 * FROM Employees ORDER BY Salary DESC", dbCon);
            SqlDataReader reader = cmdAllEmployees.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    var firstName = (string) reader["FirstName"];
                    var lastName = (string) reader["LastName"];
                    var salary = (decimal) reader["Salary"];
                    var jobTitle = (string) reader["JobTitle"];
                    Console.WriteLine("{0} {1} - {2} - {3}", firstName, lastName, salary, jobTitle);
                }
            }
        }
    }
}