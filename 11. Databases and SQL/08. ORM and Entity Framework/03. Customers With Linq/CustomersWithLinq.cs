/*
 * 3. Write a method that finds all customers who 
 * have orders made in 1997 and shipped to Canada.
 */

namespace _03.Customers_With_Linq
{
    using System;
    using System.Linq;
    using Northwind.Model;

    class CustomersWithLinq
    {
        static void Main()
        {
            using (var dbContext = new NorthwindEntities())
            {
                var customersWithOrder = dbContext.Orders
                    .Where(order =>
                                    order.ShipCountry == "Canada" &&
                                    order.OrderDate.Value.Year == 1997)
                    .Select(order => new { order.Customer })
                    .Select(c => new
                        {
                            c.Customer.CustomerID,
                            c.Customer.ContactName,
                            c.Customer.ContactTitle
                        });

                foreach (var customer in customersWithOrder)
                {
                    Console.WriteLine("{0} - {1}, {2}",
                        customer.CustomerID, 
                        customer.ContactTitle, 
                        customer.ContactName);
                }

            }
        }
    }
}
