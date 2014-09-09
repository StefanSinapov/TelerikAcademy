namespace CarsFactory.Reports.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarsFactory.Data;
    using CarsFactory.Models;
    using System.Globalization;

    public class ReportsDataCollector
    {
        public ICollection<Product> CollectDataForJsonReport(CarsFactoryContext carsFactoryContext)
        {
            var productsList = carsFactoryContext.Products.SqlQuery("SELECT * FROM PRODUCTS").ToList();

            return productsList;
        }

        public Dictionary<string, ICollection<SalesReport>> CollectDataForXmlReport(CarsFactoryContext carsFactoryContext)
        {
            var dealers = carsFactoryContext.Dealers.Select(d => new
            {
                Name = d.Name,
                SalesReports = d.SalesReports
            }).ToList();

            Dictionary<string, ICollection<SalesReport>> result = new Dictionary<string, ICollection<SalesReport>>();

            foreach (var dealer in dealers)
            {
                result[dealer.Name] = dealer.SalesReports;
            }

            return result;
        }

        public SalesReportData CollectDataForPdfReport(CarsFactoryContext carsFactoryContext)
        {
            var salesByDate = carsFactoryContext
                .Sales
                .GroupBy(s => s.SalesReport.ReportDate)
                .Select(g => new
                    {
                        Date = g.Key,
                        Sales = g.Select(s => new
                        {
                            Product = s.Product.Model + " " + s.Product.ReleaseYear,
                            Quantity = s.Quantity,
                            UnitPrice = s.UnitPrice,
                            Dealer = s.SalesReport.Dealer.Name,
                            Sum = s.Sum
                        })
                    })
                    .ToList();

            Dictionary<DateTime, KeyValuePair<decimal, List<string[]>>> result = new Dictionary<DateTime, KeyValuePair<decimal, List<string[]>>>();
            decimal grandTotal = 0;

            foreach (var day in salesByDate)
            {

                decimal dailyTotal = 0;
                List<string[]> soldProducts = new List<string[]>();
                foreach (var item in day.Sales)
                {
                    string[] row = { item.Product, item.Quantity.ToString(), item.UnitPrice.ToString("N", CultureInfo.InvariantCulture), item.Dealer, item.Sum.ToString("N", CultureInfo.InvariantCulture) };
                    dailyTotal += item.Sum;
                    soldProducts.Add(row);
                }

                grandTotal += dailyTotal;
                result[day.Date.Date] = new KeyValuePair<decimal, List<string[]>>(dailyTotal, soldProducts);
            }

            return new SalesReportData(grandTotal, result);
        }

    }
}