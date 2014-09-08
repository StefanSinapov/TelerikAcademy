/*
 * 4. Write a method that finds all customers who 
 * have orders made in 1997 and shipped to Canada.
 */
namespace _04.Customers_With_SQL
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
                var customersWithOrder = (from customer in dbContext.Customers
                                          join order in dbContext.Orders on customer.CustomerID equals order.CustomerID
                                          where order.OrderDate.Value.Year == 1994  && order.ShipCountry == "Canada"
                                          select customer).ToList();

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
