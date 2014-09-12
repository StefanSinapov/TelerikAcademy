/*
* 1. Define a class Student, which contains data about a student
* – first, middle and last name, SSN, permanent address, mobile
* phone e-mail, course, specialty, university, faculty. 
* 
* Use an enumeration for the specialties, universities and faculties.
* 
* Override the standard methods, inherited by  System.Object:
* Equals(), ToString(), GetHashCode() and operators == and !=.
* 
* 2. Add implementations of the ICloneable interface. The Clone() 
* method should deeply copy all object's fields into a new object
* of type Student.
*
* 3. Implement the  IComparable<Student> interface to compare students 
* by names (as first criteria, in lexicographic order) and by social
* security number (as second criteria, in increasing order).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
	public class Program
	{
		static void Main()
		{
			var firstStudent = new Student("Ivan", "Ivanov", "Ivanov", "9999912829", Specialty.ComputerScience, University.SofiaUniversity, Faculty.Mathematical);
			var secondStudent = new Student("Boris", "Ivanov", "Borisov", "12349", Specialty.Dental, University.MedicalUniversity, Faculty.Medical);


			Console.WriteLine(new string('-', 40));
			Console.WriteLine("firstStudent.Equals(secondStudent): {0}", firstStudent.Equals(secondStudent));
			Console.WriteLine("firstStudent == secondStudent: {0}", firstStudent == secondStudent);
			Console.WriteLine("firstStudent != secondStudent: {0}\n\n", firstStudent != secondStudent);


			Console.WriteLine("firstStudent.GetHashCode(): {0}", firstStudent.GetHashCode());
			Console.WriteLine("secondStudent.GetHashCode(): {0}\n\n", secondStudent.GetHashCode());

			var clonedStudent = firstStudent.Clone();
			Console.WriteLine("Clonet student :\n{0}",clonedStudent);
		}
	}
}
