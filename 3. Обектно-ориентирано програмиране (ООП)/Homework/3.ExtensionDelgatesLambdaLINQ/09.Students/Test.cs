/*
 * 9.  []Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. 
 * Create a List<Student> with sample students. 
 * Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
 * 10. []Implement the previous using the same query expressed with extension methods.
 * 11. []Extract all students that have email in abv.bg. Use string methods and LINQ.
 * 12. []Extract all students with phones in Sofia. Use LINQ.
 * 13. []Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
 * 14. []Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
 * 15. []Extract all Marks of the students that enrolled in 2006. 
 * (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
 * 16. []Create a class Group with properties GroupNumber and DepartmentName.
 * Introduce a property Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTest
{
	class Test
	{
		private static void Print(IEnumerable<Student> students)
		{
			foreach (var student in students)
			{
				Console.WriteLine(student);
				Console.WriteLine();

			}
			Console.WriteLine("---------------------");
		}
		static List<Student> students;
		static void Main(string[] args)
		{

			#region Add some students
			students = new List<Student>()
				{
					new Student("Pesho","Peshov","61244","0899819384","pesho@gmail.com",new List<int>(){2,4,5,3,3,3},3),
					new Student("Ivan","Ivanov","61724","0884888888","i.ivanov@abv.bg",new List<int>(){6,3,4,3,3},1),
					new Student("George","Simeonov","58271","02/123456","sim@gmail.com",new List<int>(){6,6,3,5,6},2),
					new Student("Dimitar","Poibrenski","98623","0898989898","dimi@abv.bg",new List<int>(){3,4,2,2,2},2),
					new Student("Spas","Grozdanov","21832","0889991199","spascho_picha@abv.com",new List<int>(){2,2,2,3,5},3),
				};
			#endregion

			//Task 9. Students from group 2, ordered by first name ----------LINQ-------------
			var studentsFromSecondGroup =
				from student in students
				where student.GroupNumber == 2
				orderby student.FirstName
				select student;
			Print(studentsFromSecondGroup);

			//Task 10 -----------Lambda--------------
			Console.WriteLine("\n Task 10");
			studentsFromSecondGroup = students.Where(s => s.GroupNumber == 2).OrderBy(s => s.FirstName);
			Print(studentsFromSecondGroup);

			Console.WriteLine("Task 11 all students that have email in abv.bg");
			var studentsWithAbvEmail = students.Where(s => s.Email.EndsWith("abv.bg"));
			Print(studentsWithAbvEmail);

			Console.WriteLine("Task 12 all students with phones in Sofia.");
			var studentsWithPhoneInSofia = students.Where(s => s.PhoneNumber.StartsWith("02"));
			Print(studentsWithPhoneInSofia);


			Console.WriteLine("Task 13 Students with at least one 6 into new anonymous class");
			var studentsWithExcellentMark = students.Where(st => st.Marks.Contains(6)).Select
				(st => new { FullName = st.FirstName + " " + st.LastName, Marks = string.Join(",", st.Marks.Select(i => i.ToString().ToArray())) });
			foreach (var student in studentsWithExcellentMark)
			{
				Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);

			}


			Console.WriteLine("\nTask 14");
			var studentsWithExactlyTwoMarks2Lambda = students.Where(st => st.Marks.Count(m => m == 2) == 2).Select(st => new { FullName = st.FirstName + " " + st.LastName, Marks = st.Marks.Select(m => m.ToString()) });

			foreach (var student in studentsWithExactlyTwoMarks2Lambda)
			{
				Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);

			}

		}
	}
}
