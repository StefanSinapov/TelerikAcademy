namespace CarsFactory.Reports
{
    using System;
    using System.Linq;
    using CarsFactory.Data;
    using Data;
    using Newtonsoft.Json;
    using System.IO;


    public static class JsonRepor
    {
        public static void GenerateJsonReports(CarsFactoryContext carsFactoryContext, ReportsDataCollector collector)
        {
            var productsList = collector.CollectDataForJsonReport(carsFactoryContext); //carsFactoryContext.Products.SqlQuery("SELECT * FROM PRODUCTS").ToList();

            foreach (var item in productsList)
            {
                int id = item.Id;
                string jsonReportPath = @"..\..\..\Json-Reports\" + id + ".json";

                StreamWriter writer = new StreamWriter(jsonReportPath, false);

                string productAsJson = JsonConvert.SerializeObject(item, Formatting.Indented);

                using (writer)
                {
                    writer.WriteLine(productAsJson);
                }
            }
        }
    }
}