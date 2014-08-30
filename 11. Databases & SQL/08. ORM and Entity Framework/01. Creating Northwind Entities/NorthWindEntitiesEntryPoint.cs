/*
 * 1. Using the Visual Studio Entity Framework 
 * designer create a `DbContext` for the `Northwind` database
 */
namespace _01.Creating_Northwind_Entities
{
    using System;
    using System.Linq;
    using Northwind.Model;

    class NorthWindEntitiesEntryPoint
    {
        static void Main()
        {
            var northwindDb = new NorthwindEntities();

            using (northwindDb)
            {
                var categories = northwindDb.Categories.Select(category =>
                    new
                    {
                        Name = category.CategoryName,
                        category.Description
                    });

                foreach (var category in categories)
                {
                    Console.WriteLine("Category {0} - {1}", category.Name, category.Description);
                }
            }
        }
    }
}
