/*
* 2. Define abstract class Human with first name and last name.
* Define new class Student which is derived from Human and has
* new firstName – grade. Define class Worker derived from Human with
* new property WeekSalary and WorkHoursPerDay and method MoneyPerHour()
* that returns money earned by hour by the worker. Define the proper
* constructors and properties for this hierarchy. 
* [x] Initialize a list of 10 students and sort them by grade in ascending order
* (use LINQ or OrderBy() extension method). 
* [] Initialize a list of 10 workers and sort them by money per hour in descending order.
* Merge the lists and sort them by first name and last name.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Human
{
	class Program
	{
		static void Main()
		{
			//Students
			Console.WriteLine("--------Students");
			List<Student> students = new List<Student>()
			{
				new Student("Stefan","Sinapov",4),
				new Student("Pesho", "Peshev", 6),
				new Student("Ivan", "Ivanov",2),
				new Student("Svetlin","Nakov",6),
				new Student("Jivko","Todorov",2),
				new Student("George","Serev",3),
				new Student("Miro","Georgiev",4),
				new Student("Dimitar","Spasov",6),
				new Student("Dimitriika","Ivanova",5),
				new Student("Petya","Filipova",4)
			};

			students = students.OrderBy(s => s.Grade).ToList();
			foreach (var student in students)
			{
				Console.WriteLine(student);
			}


			//Workers
			Console.WriteLine("\n----------Workers");
			List<Worker> workers = new List<Worker>()
			{
				new Worker("Lubomir", "Sinapov",500,7),
				new Worker("Kristian", "Peshev",120,8),
				new Worker("Tonislav", "Ivanov",100,8),
				new Worker("Pavlin", "Nakov",800,6),
				new Worker("Cvetan", "Todorov",300,10),
				new Worker("Ivailo", "Serev",300,8),
				new Worker("Kaloyan", "Georgiev",150,10),
				new Worker("Dimiter", "Spasov",130,6),
				new Worker("Marin", "Ivanova",90,4),
				new Worker("Marin", "Filipova",500,8)
			};
			workers = workers.OrderByDescending(w => w.MoneyPerHour()).ToList();
			foreach (var worker in workers)
			{
				Console.WriteLine(worker);
			}


			//join students and workers
			Console.WriteLine("\n--------All");
			List<Human> humans = new List<Human>();
			humans.AddRange(students);
			humans.AddRange(workers);

			humans = humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName).ToList();
			foreach (var human in humans)
			{
				Console.WriteLine(human);
			}
		}
	}
}
