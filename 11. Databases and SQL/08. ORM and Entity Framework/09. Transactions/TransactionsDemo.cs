/*
 * 9. Create a method that places a new order in the Northwind database.
 * The order should contain several order items. 
 * Use transaction to ensure the data consistency.
 */

namespace _09.Transactions
{
    using System;
    using Northwind.Model;

    class TransactionsDemo
    {
        public static void Main()
        {
            Console.WriteLine("({0} affected row(s))\n", TestOnExplicitlyStartedTransaction());
            Console.WriteLine("({0} affected row(s))\n", TestOnImplicitlyStartedTransaction());
        }

        /// <summary>
        /// Started the transaction explicitly. We have options to commit / roll-back transactions.
        /// </summary>
        private static int TestOnExplicitlyStartedTransaction()
        {
            var affectedRows = 0;
            const string customerId = "VINET";
            const int employeeId = 5;

            const int invalidEmployeeId = int.MaxValue;

            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Database.Initialize(false);
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        #region [Add Orders]

                        // This cause an error (Comment it to see result)
                        var firstOrder = new Order
                        {
                            CustomerID = customerId,
                            EmployeeID = invalidEmployeeId // employeeId
                        };
                        dbContext.Orders.Add(firstOrder);

                        var secondOrder = new Order
                        {
                            CustomerID = customerId,
                            EmployeeID = employeeId
                        };

                        secondOrder.Order_Details.Add(new Order_Detail
                        {
                            OrderID = secondOrder.OrderID,
                            ProductID = 5,
                            UnitPrice = 12.34m,
                            Quantity = 100,
                            Discount = 0.2f
                        });

                        dbContext.Orders.Add(secondOrder);

                        #endregion

                        affectedRows = dbContext.SaveChanges();

                        // Finish successfully => Commit transaction
                        transaction.Commit();

                        // Test to Rollback() insted of Commit() and you will see that the changes are rolled-back
                        //transaction.Rollback();

                        Console.WriteLine("- Finish successfully => Commit transaction");
                    }
                    catch (Exception)
                    {
                        // Finish Unsuccessfully => Rollback transaction
                        transaction.Rollback();

                        Console.WriteLine("- Exception: Finish Unsuccessfully => Rollback transaction");
                    }
                }
            }

            return affectedRows;
        }

        /// <summary>
        /// Started the transaction implicitly. 
        /// </summary>
        private static int TestOnImplicitlyStartedTransaction()
        {
            var affectedRows = 0;
            const string customerId = "RATTC";
            const int employeeId = 6;

            const int invalidEmployeeId = int.MaxValue;

            using (var dbContext = new NorthwindEntities())
            {
                try
                {
                    #region [Add Orders]

                    // This cause an error
                    var firstOrder = new Order
                    {
                        CustomerID = customerId,
                        EmployeeID = invalidEmployeeId // employeeId
                    };

                    dbContext.Orders.Add(firstOrder);

                    var secondOrder = new Order
                    {
                        CustomerID = customerId,
                        EmployeeID = employeeId
                    };

                    secondOrder.Order_Details.Add(new Order_Detail
                    {
                        OrderID = secondOrder.OrderID,
                        ProductID = 5,
                        UnitPrice = 12.34m,
                        Quantity = 100,
                        Discount = 0.2f
                    });

                    dbContext.Orders.Add(secondOrder);

                    #endregion

                    affectedRows = dbContext.SaveChanges();

                    Console.WriteLine("- Finish successfully => Commit transaction");
                }
                catch (Exception)
                {
                    Console.WriteLine("- Exception: Finish Unsuccessfully => Rollback transaction");
                }
            }

            return affectedRows;
        }
    }
}
