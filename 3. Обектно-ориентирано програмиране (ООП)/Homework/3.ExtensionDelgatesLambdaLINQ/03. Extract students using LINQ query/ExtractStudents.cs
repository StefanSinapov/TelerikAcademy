/*
* 3. Write a method that from a given array of students
* finds all students whose first name is before its last
* name alphabetically. Use LINQ query operators.
*/

/*
* 4. Write a LINQ query that finds the first name
* and last name of all students with age between 18 and 24.
*/

using System;
using System.Linq;

class ExtractStudents
{
	static void Main()
	{
		var students = new[]
        {
            new { FirstName = "Stefan", LastName = "Georgiev", Age = 23 },
            new { FirstName = "Ivan", LastName = "Ivanov", Age = 17 },
            new { FirstName = "Jivka", LastName = "Dimitrova", Age = 45 },
            new { FirstName = "Boris", LastName = "Angelov", Age = 18 },
            new { FirstName = "Angel", LastName = "Goshov", Age = 20 },
        };

		// Linq query
		var linqQuery =
				   from student in students
				   where student.FirstName.CompareTo(student.LastName) < 0
				   select student;

		// Lambda query
		var extensionMethod = students.Where(student => student.FirstName.CompareTo(student.LastName) < 0);

		Console.WriteLine("#1: Using LINQ query: ");
		Console.WriteLine(string.Join(Environment.NewLine, linqQuery));

		Console.WriteLine("\n#2: Using Extension method: ");
		Console.WriteLine(string.Join(Environment.NewLine, extensionMethod));



		//Second task
		// Linq query
		var query =
				   from student in students
				   where student.Age >= 18 && student.Age <= 24
				   select new { student.FirstName, student.LastName, student.Age };

		Console.WriteLine("\n\n---------Students between 18 - 24 years---------");
		Console.WriteLine("#1: Using LINQ query: ");
		Console.WriteLine(string.Join(Environment.NewLine, query));
	}
}