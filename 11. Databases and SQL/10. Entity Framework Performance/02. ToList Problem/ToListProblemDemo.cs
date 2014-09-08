////2. Using Entity Framework write a query that selects 
////    all employees from the Telerik Academy database, 
////    then invokes ToList(), then selects their addresses, 
////    then invokes ToList(), then selects their towns, then 
////    invokes ToList() and finally checks whether the town is "Sofia". 
////    Rewrite the same in more optimized way and compare the performance.


namespace _02.ToList_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using TelerikAcademyEntities;

    class ToListProblemDemo
    {
        private static readonly Stopwatch timer = new Stopwatch();

        static void Main()
        {
            var context = new TelerikAcademyEntities();

            using (context)
            {
                Console.WriteLine("Using multiple .ToList():");
                timer.Start();
                var employees = context.Employees.ToList()
                                .Select(e => e.Address).ToList()
                                .Select(a => a.Town).ToList()
                                .Where(t => t.Name == "Sofia")
                                .ToList();
                timer.Stop();
                Console.WriteLine("{0} employees selected", employees.Count);
                Console.WriteLine("Time: {0}", timer.Elapsed);

                
                Console.WriteLine("Using one .ToList():");
                timer.Restart();
                var employeesFast = context.Employees
                                .Select(e => e.Address)
                                .Select(a => a.Town)
                                .Where(t => t.Name == "Sofia")
                                .ToList();
                timer.Stop();
                Console.WriteLine("{0} employees selected", employeesFast.Count);
                Console.WriteLine("Time: {0}", timer.Elapsed);

            }
        }
    }
}
