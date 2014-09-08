/*
 * 5. Write a method that finds all the sales 
 * by specified region and period (start / end dates).
 */
namespace _05.Sales_By_Region_And_Period
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Northwind.Model;

    internal class SalesByRegionAndPeriod
    {
        private static void Main()
        {
            string region = "SP";
            var startDate = new DateTime(1993, 2, 10);
            var endDate = new DateTime(1999, 6, 23);

            using (var dbContext = new NorthwindEntities())
            {
                var sales = dbContext.Orders.Where(order =>
                    order.ShipRegion == region &&
                    order.OrderDate >= startDate &&
                    order.OrderDate <= endDate)
                    .Select(order => new
                        {
                            Date = order.OrderDate.Value,
                            order.ShipName,
                            order.ShipRegion
                        });

                foreach (var sale in sales)
                {
                    Console.WriteLine("{0} - {1} - {2}", sale.ShipName, sale.ShipRegion, sale.Date);
                }
            }
        }
    }
}