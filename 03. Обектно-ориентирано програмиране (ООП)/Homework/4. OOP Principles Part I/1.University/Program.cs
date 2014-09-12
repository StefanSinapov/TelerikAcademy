/*
 * We are given a **school**. In the school there are classes of students. 
 * Each class has a set of teachers. Each teacher teaches a set of disciplines.
 * Students have name and unique class number. Classes have unique text identifier.
 * Teachers have name. Disciplines have name, number of lectures and number of exercises. 
 * Both teachers and students are people. Students, classes, teachers and disciplines
 * could have optional comments (free text block).

 * Your task is to identify the classes (in terms of  OOP) and their attributes and operations, 
 * encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
	class Program
	{
		static void Main()
		{
			//Create new university
			University softUni = new University("Software University \"Svetlin Nakov\" ");
			Console.WriteLine(softUni);

			//Add some Diciplines
			Discipline OOP = new Discipline("Object Oriented Programming", 10, 15);
			Discipline cSharp = new Discipline("C# Part I", 13, 20);
			Discipline javaScript = new Discipline("Java Script", 10, 9);

			//Add some Teachers
			Teacher nakov = new Teacher("Svetlin", "Nakov");
			Teacher pesho = new Teacher("Pesho", "Peshev");

			nakov.AddDiscipline(OOP, cSharp);
			pesho.AddDiscipline(OOP, cSharp, javaScript);

			Console.WriteLine(nakov);

			//Add some Students
			List<Student> students = new List<Student>()
			{
				new Student("George","Georgiev","125"),
				new Student("Stefan", "Sinapov","61714"),
				new Student("Ivan", "Ivanov","12041"),
				new Student("Gibraltar", "Ibrahimob","12342"),
				new Student("Haine", "Salimov","988"),
				new Student("Salim", "Hainemov","734"),
			};

			//add some classes
			Class softwareEngineering = new Class("Software Engineering 1st Semester");
			softwareEngineering.AddTeacher(nakov, pesho);
			softwareEngineering.AddStudent(students);

			softUni.AddClass(softwareEngineering);

			Console.WriteLine(softUni);

		}
	}
}
