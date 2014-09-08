namespace _06.Create_Database_Twin
{
    using System;
    using System.Linq;
    using Northwind.Model;

    class CreateDatabaseTwin
    {
        static void Main()
        {
            /*
             * In App.Config I change data catalog to NorthwindTwin
             */

            var dbContext = new NorthwindEntities();
            using (dbContext)
            {
                dbContext.Database.CreateIfNotExists();
            }
        }
    }
}
