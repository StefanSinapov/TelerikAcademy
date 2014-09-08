//1. Using Entity Framework write a SQL query
//to select all employees from the Telerik Academy
//database and later print their name, department and town.
//Try the both variants: with and without .Include(…). 
//Compare the number of executed SQL statements and the performance.

namespace _01.N_plus_One_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using TelerikAcademyEntities;

    class NPlusOneProblemDemo
    {
        private static readonly Stopwatch timer = new Stopwatch();

        static void Main()
        {
            var context = new TelerikAcademyEntities();

            using (context)
            {
                Console.WriteLine("Using plain queries");
                timer.Start();
                var allEmployees = context.Employees;
                foreach (var employee in allEmployees)
	            {
		             Console.WriteLine("{0} {1} - {2} - {3}", 
                                         employee.FirstName, employee.LastName, 
                                         employee.Department.Name, employee.Address.Town.Name);
	            }
                timer.Stop();
                Console.WriteLine("Time: {0}", timer.Elapsed);
                

                Console.WriteLine("\nUsing .Include");
                timer.Restart();
                var allEmpoyeesFast = context.Employees.Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    Town = e.Address.Town.Name
                });
                foreach (var employee in allEmpoyeesFast)
	            {
		             Console.WriteLine("{0} {1} - {2} - {3}", 
                                         employee.FirstName, employee.LastName, 
                                         employee.DepartmentName, employee.Town);
	            }
                timer.Stop();
                Console.WriteLine("Time: {0}", timer.Elapsed);
            }
        }
    }
}
