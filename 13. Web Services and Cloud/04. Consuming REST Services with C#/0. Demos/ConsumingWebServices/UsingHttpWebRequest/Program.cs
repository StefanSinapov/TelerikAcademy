using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UsingHttpWebRequest
{
    class Program
    {
        static string studentsServiceUrl = "http://localhost:7232/api/";

        static void Main(string[] args)
        {
            var students = GetStudents();
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
            Console.WriteLine("---------------");

            AddNewStudent();

            students = GetStudents();
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }

        private static void AddNewStudent()
        {
            var newBook = new Student()
            {
                FirstName = "George",
                LastName = "Carlin"
            };
            HttpRequester.Post(studentsServiceUrl + "students", newBook);
        }

        static IEnumerable<Student> GetStudents()
        {
            var students = HttpRequester.Get<IEnumerable<Student>>(studentsServiceUrl + "students");
            return students;
        }
    }

    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
