namespace _07.Write_to_MS_Excel
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;

    public class WriteToMsExcel
    {
        /*
         * NOTE: Excel file is in root directory of the homework - Scores.xlsx
         */
        public static void Main()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Score: ");
            var score = Console.ReadLine();

            string connectionString = ConfigurationManager.ConnectionStrings["MSExcel"].ConnectionString;
            var excelOleDbConnection = new OleDbConnection(connectionString);
            excelOleDbConnection.Open();

            var sheetName = GeSheetName(excelOleDbConnection);
            var insertCommand = new OleDbCommand("INSERT INTO [" + sheetName + "] Values (@name, @score)",
                                    excelOleDbConnection);
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@score", score);


            using (excelOleDbConnection)
            {
                try
                {
                    insertCommand.ExecuteNonQuery();
                    Console.WriteLine("1 new record added.");
                }
                catch
                {
                    Console.WriteLine("Something went wrong during inserting.");
                }
            }
        }

        private static string GeSheetName(OleDbConnection excelOleDbConnection)
        {
            DataTable excelSchema = excelOleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (excelSchema == null)
            {
                throw new ArgumentNullException();
            }
            string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
            return sheetName;
        }
    }
}
