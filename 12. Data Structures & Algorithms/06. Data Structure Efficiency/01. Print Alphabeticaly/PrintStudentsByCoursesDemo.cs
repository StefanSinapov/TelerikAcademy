/*
 * A text file students.txt holds information about students and their courses in the following format:
	```
		Kiril  | Ivanov   | C#
		Stefka | Nikolova | SQL
		Stela  | Mineva   | Java
		Milena | Petrova  | C#
		Ivan   | Grigorov | C#
		Ivan   | Kolev    | SQL
	```
	Using SortedDictionary<K,T> print the courses 
 * in alphabetical order and for each of them prints 
 * the students ordered by family and then by name:
	```
		C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
		Java: Stela Mineva
		SQL: Ivan Kolev, Stefka Nikolova
	```
 */
namespace _01.Print_Alphabeticaly
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PrintStudentsByCoursesDemo
    {
        static void Main()
        {
            var students = new SortedDictionary<string, HashSet<Student>>();
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../students.txt"));
#endif
            ReadInput(students);

            foreach (var pair in students)
            {
                Console.WriteLine("{0}: {1}", pair.Key, string.Join(", ", pair.Value
                                                                .OrderBy(s => s.LastName)
                                                                .ThenBy(s => s.FirstName)));
            }
        }

        private static void ReadInput(IDictionary<string, HashSet<Student>> students)
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                var values = input.Split(new[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstName = values[0];
                var lastName = values[1];
                var courseName = values[2];

                if (!students.ContainsKey(courseName))
                {
                    students.Add(courseName, new HashSet<Student>());
                }
                students[courseName].Add(new Student(firstName, lastName));

                input = Console.ReadLine();
            }
        }
    }
}
