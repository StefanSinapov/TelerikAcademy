namespace CarsFactory.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    using CarsFactory.Models;
    using CarsFactory.Data;

    public class ZipImporter
    {
        private string zipPath;
        private string unzipDirectory;

        public ZipImporter(string zipPath, string unzipDirectory)
        {
            this.zipPath = zipPath;
            this.unzipDirectory = unzipDirectory;
        }

        public void ReadAndImport(CarsFactoryContext context)
        {
            Console.WriteLine("Unziping...");
            ZipFile.ExtractToDirectory(zipPath, unzipDirectory);

            Console.WriteLine("Findind Excel files...");
            var allExcelFilesPath = FindExcelFiles(unzipDirectory);
            var filesCount = 0;

            foreach (var list in allExcelFilesPath.Values)
                filesCount += list.Count;
            Console.WriteLine("Found: {0} files", filesCount);

            Console.WriteLine("Importing...");
            foreach (var period in allExcelFilesPath)
            {
                foreach (var file in period.Value)
                {
                    DataTable content = GetExcelContent(file);
                    ImportContentToDB(period.Key, content, context);
                }
            }

            Console.WriteLine("Succesfully imported files!");
            Directory.Delete(unzipDirectory, true);
        }

        private void ImportContentToDB(string period, DataTable content, CarsFactoryContext context)
        {
            var dealerName = content.Rows[0][0].ToString();
            int dealerID;

            try
            {
                dealerID = context.Dealers
                    .Where(d => d.Name == dealerName)
                    .Select(d => d.Id)
                    .First();
            }
            catch (Exception)
            {
                Console.WriteLine("There isn't any dealers in DB with name: {0}", dealerName);
                return;
            }

            var totalSum = Convert.ToInt32(content.Rows[content.Rows.Count - 1][3]);
            var date = DateTime.Parse(period);
            var report = new SalesReport()
            {
                ReportDate = date,
                TotalSum = totalSum,
                DealerId = dealerID
            };

            for (int i = 2; i < content.Rows.Count - 1; i++)
            {
                var productID = Convert.ToInt32(content.Rows[i][0]);
                var quantity = Convert.ToInt32(content.Rows[i][1]);
                var price = Convert.ToDecimal(content.Rows[i][2]);
                var sum = Convert.ToDecimal(content.Rows[i][3]);

                report.Sales.Add(new Sale()
                {
                    ProductId = productID,
                    Quantity = quantity,
                    UnitPrice = price,
                    Sum = sum
                });

                context.SalesReports.Add(report);
            }

            context.SaveChanges();
        }

        private DataTable GetExcelContent(string file)
        {
            var result = new DataTable("newtable");
            var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties=Excel 12.0;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                var selectSql = @"SELECT * FROM [Sales$]";

                connection.Open();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.FillSchema(result, SchemaType.Source);
                    adapter.Fill(result);
                }

                connection.Close();
            }

            return result;
        }

        private Dictionary<string, List<string>> FindExcelFiles(string directoryPath)
        {
            var excelPaths = new Dictionary<string, List<string>>();
            var directories = Directory.EnumerateDirectories(directoryPath);

            foreach (var directory in directories)
            {
                var directoryInfo = new FileInfo(directory);
                var dirName = directoryInfo.Name;
                var files = Directory.EnumerateFiles(directory, "*.xls").ToArray();
                var excelfiles = new List<string>(files);

                excelPaths.Add(directoryInfo.Name, excelfiles);
            }

            return excelPaths;
        }
    }
}
