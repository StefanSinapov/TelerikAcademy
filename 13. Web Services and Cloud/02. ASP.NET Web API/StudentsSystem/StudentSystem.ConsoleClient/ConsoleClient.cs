namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using Data.Contracts;
    using Data;

    public class ConsoleClient
    {
        public static void Main()
        {
            Console.Write("Loading...");

            var forumSystemContext = new StudentSystemData(new StudentSystemContext());

            PrintStudents(forumSystemContext);
            PrintCourses(forumSystemContext);
            PrintHomeworks(forumSystemContext);
        }
 
        private static void PrintStudents(IStudentSystemData studentSystemData)
        {
            Console.WriteLine("\rStudents: ");
            foreach (var student in studentSystemData.Students.All().ToList())
            {
                Console.WriteLine(" - {0} -> present in {1} course(s).", student.Name, student.Courses.Count());
            }
        }

        private static void PrintCourses(IStudentSystemData studentSystemData)
        {
            Console.WriteLine("\nCourses: ");
            foreach (var course in studentSystemData.Courses.All().ToList())
            {
                Console.WriteLine(" - {0} -> has {1} homework(s).", course.Description, course.Homeworks.Count());
            }
        }

        private static void PrintHomeworks(IStudentSystemData studentSystemData)
        {
            Console.WriteLine("\nHomeworks: ");
            foreach (var homework in studentSystemData.Homeworks.All().Where(h => !h.StudentId.HasValue).ToList())
            {
                Console.WriteLine(" - {0} ({1}) -> has {2} material(s).",
                    homework.Content, homework.Course.Description, homework.Materials.Count());

                foreach (var material in homework.Materials)
                {
                    Console.WriteLine("    - {0} ({2}) - {1}", material.Type, material.DownloadUrl, material.Homework.Content);
                }

                Console.WriteLine();
            }
        }
    }
}