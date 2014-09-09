namespace CarsFactory.ConsoleClient
{
    using System;
    using MySQL.Data;
    using Data;
    using Loaders;
    using Reports;
    using MongoDB.Data;
    using Reports.Data;

    public class EntryPoint
    {
        public static void Main()
        {
            StartApplication();
        }

        private static void StartApplication()
        {
            var carsFactoryContext = new CarsFactoryContext();
            var collector = new ReportsDataCollector();
            var mongoDbContext = new MongoDbContext();

            using (carsFactoryContext)
            {

                LoadDataFromMongoDb(carsFactoryContext, mongoDbContext);
                ZipReadingAndImporting(carsFactoryContext);

                GeneratePdfReports(carsFactoryContext, collector);
                GenerateXmlReports(carsFactoryContext, collector);
                GenerateJsonReports(carsFactoryContext, collector);
                LoadXmlFileToSqlAndMongo(carsFactoryContext, mongoDbContext);
                GenerateExcelReports();
            }
        }

        private static void GenerateExcelReports()
        {
            TaskOperationMessage("Problem #6 –Excel data");
            const string operationText = "Generating Excel report";
            try
            {
                ExcelReport.GenerateExcelReports();
                SuccessOperationMessage(operationText);
            }
            catch
            {
                ErrorOperationMessage(operationText);
            }
        }

        private static void GenerateXmlReports(CarsFactoryContext carsFactoryContext, ReportsDataCollector collector)
        {
            TaskOperationMessage("Problem #3 – Generate XML Report");
            const string operationText = "Generating XML report";
            try
            {
                XmlReport.GenerateXmlReports(carsFactoryContext, collector);
                SuccessOperationMessage(operationText);
            }
            catch
            {
                ErrorOperationMessage(operationText);
            }
        }

        private static void GenerateJsonReports(CarsFactoryContext carsFactoryContext, ReportsDataCollector collector)
        {
            TaskOperationMessage("Problem #4 – JSON Reports");
            const string operationText = "Generating JSON report";
            try
            {
                JsonRepor.GenerateJsonReports(carsFactoryContext, collector);
                SuccessOperationMessage(operationText);
            }
            catch
            {
                ErrorOperationMessage(operationText);
            }

            try
            {
                CarsFactoryMySQLData.GenerateProducts(carsFactoryContext);
                SuccessOperationMessage("Data loading to MySQL");
            }
            catch (Exception)
            {
                ErrorOperationMessage("data loading to MySQL");
            }
        }

        private static void GeneratePdfReports(CarsFactoryContext carsFactoryContext, ReportsDataCollector collector)
        {
            TaskOperationMessage("Problem #2 – Generate PDF Reports");
            const string operationText = "Generating PDF report";
            try
            {
                PdfReport.GeneratePdfReport(carsFactoryContext, collector);
                SuccessOperationMessage(operationText);

            }
            catch
            {
                ErrorOperationMessage(operationText);
            }
        }

        private static void LoadXmlFileToSqlAndMongo(CarsFactoryContext carsFactoryContext, MongoDbContext mongoDbContext)
        {
            TaskOperationMessage("Problem #5. Load data from XML");

            const string operationText = "Reading XML Data";
            try
            {
                var mongoDbXmlLoader = new MongoDbXmlLoader(mongoDbContext);
                XmlLoader.LoadXmlFile(carsFactoryContext, mongoDbXmlLoader);
                SuccessOperationMessage(operationText);

            }
            catch
            {
                ErrorOperationMessage(operationText);
            }
        }

        private static void LoadDataFromMongoDb(CarsFactoryContext carsFactoryContext, MongoDbContext mongoDbContext)
        {
            Console.WriteLine("Loading Data From MongoDB to MS SQL Server...");

            var mongoDbLoader = new MongoDbToSqlLoader(carsFactoryContext, mongoDbContext);
            int newRecordsCount = mongoDbLoader.LoadAll();

            Console.WriteLine("     {0} new record(s) added", newRecordsCount);
            SuccessOperationMessage("Loading from MongoDb");
        }

        private static void ZipReadingAndImporting(CarsFactoryContext carsFactoryContext)
        {
            TaskOperationMessage("Problem #1 – Load Excel Reports from ZIP File");

            var zipPath = @"..\..\..\Sample-Sales-Reports.zip";
            var unzipDirectory = @"..\..\..\TempExtractZip";
            var zipReader = new ZipImporter(zipPath, unzipDirectory);

            try
            {
                zipReader.ReadAndImport(carsFactoryContext);

                SuccessOperationMessage("Unzipping");
            }
            catch
            {
                ErrorOperationMessage("unzipping");
            }
        }

        private static void SuccessOperationMessage(string operation)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     {0} done.", operation);
            Console.ResetColor();
        }

        private static void TaskOperationMessage(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void ErrorOperationMessage(string reason)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ops, something went wrong during {0}!", reason);
            Console.ResetColor();
        }
    }
}