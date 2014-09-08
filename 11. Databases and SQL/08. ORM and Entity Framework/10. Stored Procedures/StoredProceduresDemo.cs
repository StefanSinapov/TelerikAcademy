/*
 * 10. Create a stored procedures in the
 * Northwind database for finding the total incomes 
 * for given supplier name and period (start date, end date).
 * Implement a C# method that calls the stored procedure and 
 * returns the returned record set.
 */
namespace _10.Stored_Procedures
{
    using System;
    using System.Linq;
    using Northwind.Model;

    class StoredProceduresDemo
    {
        static void Main()
        {
            var supplierName = "Exotic Liquids";
            var startDate = new DateTime(1996, 1, 1);
            var endDate = new DateTime(1997, 12, 31);

            using (var northwindEntities = new NorthwindEntities())
            {
                var totalIncomes = northwindEntities.
                    usp_TotalIncomesOfSupplier(supplierName, startDate, endDate).Single();

                Console.WriteLine("Total incomes: {0:C}", totalIncomes);
            }
        }
    }
}
