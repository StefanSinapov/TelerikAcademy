/*
 * 2. Create a DAO class with static methods which provide 
 * functionality for inserting, modifying and deleting customers. 
 * Write a testing class.
 */
namespace _02.Data_Access_Objects
{
    using System;
    using Northwind.Model;

    class DataAccessDemo
    {
        static void Main()
        {
            var db = new NorthwindDao();

            var customer = new Customer
            {
                CustomerID = "Test1",
                CompanyName = "Our Company Inc.",
                ContactName = "Pesho",
                ContactTitle = "Test Title"
            };

            Console.WriteLine("{0} customer(s) added.", db.InsertCustomer(customer));

            Console.WriteLine("{0} customer(s) updated.", db.ModifyCustomer("Test1", "Some other Company"));

            Console.WriteLine("{0} customer(s) deleted.", db.DeleteCustomerById("Test1"));
        }
    }
}
