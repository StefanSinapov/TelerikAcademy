namespace _06.Read_MS_Excel
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;

    public class ReadMsExcel
    {
        public static void Main()
        {
            /*
             * NOTE: Excel file is in root directory of the homework - Scores.xlsx
             */
            string connectionString = ConfigurationManager.ConnectionStrings["MSExcel"].ConnectionString;
            var excelOleDbConnection = new OleDbConnection(connectionString);
            excelOleDbConnection.Open();

            var sheetName = GeSheetName(excelOleDbConnection);
            var readAllCommand = new OleDbCommand(
                                    "SELECT * FROM ["+ sheetName + "] WHERE Name IS NOT NULL", 
                                    excelOleDbConnection);

            using (excelOleDbConnection)
            {
                using (var dataAdapter = new OleDbDataAdapter(readAllCommand))
                {
                    var dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    using (DataTableReader reader = dataTable.CreateDataReader())
                    {
                        while (reader.Read())
                        {
                            var fullName = (string)reader["Name"];
                            var score = (double)reader["Score"];
                            Console.WriteLine("The {0} score is: {1}", fullName, score);
                        }
                    }
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
