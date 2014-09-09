namespace CarsFactory.Reports
{
    using System.IO;
    using System.Collections.Generic;

    using OfficeOpenXml;

    using CarsFactory.MySQL.Data;
    using CarsFactory.MySQL.Models;
    using CarsFactory.SQLite.Data;

    public class ExcelReport
    {
        private const string FilePath = ".../.../../Excel Reports/Cars Factory Rejection.xlsx";

        public static void GenerateExcelReports()
        {
            CarsFactorySQLiteData productsRejection = new CarsFactorySQLiteData();

            try
            {
                productsRejection.ConnectToDB();

                var products = CarsFactoryMySQLData.GetData();
                var productsRejectionAsList = productsRejection.GetData();

                GetFile(FilePath, products, productsRejectionAsList);
            }
            finally
            {
                productsRejection.DisconnectFromDB();
            }
        }

        public static void GetFile(string fileName,
                                   IEnumerable<Product> products,
                                   IEnumerable<ProductRejection> productsRejection)
        {
            var file = new FileInfo(fileName);
            file.Delete();

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Rejection");

                worksheet.Cells[1, 1].Value = "Manufacturer";
                worksheet.Cells[1, 2].Value = "Model";
                worksheet.Cells[1, 3].Value = "Rejection count";

                int counter = 2;

                foreach (var product in products)
                {
                    worksheet.Cells[counter, 1].Value = product.ManufacturerName;
                    worksheet.Cells[counter, 2].Value = product.Model;

                    bool existInSQLite = false;

                    foreach (var productRejection in productsRejection)
                    {
                        if (product.Model == productRejection.Model)
                        {
                            worksheet.Cells[counter, 3].Value = productRejection.RejectionCount;
                            existInSQLite = true;
                            break;
                        }
                    }

                    if (!existInSQLite)
                    {
                        worksheet.Cells[counter, 3].Value = 0;
                    }

                    counter++;
                }

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();

                package.Save();
            }
        }
    }
}