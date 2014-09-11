using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsingWebClient.Models;

namespace UsingWebClient
{
    class Program
    {
        static string studentServiceUrl = "http://localhost:7232/api/";

        static void Main()
        {
            var students = WebClientRequester.Get<IEnumerable<Student>>(studentServiceUrl + "students");
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
            Console.WriteLine("---------------------------");

            var st = new Student()
            {
                FirstName = "Gosho",
                LastName = "Petrov"
            };

            WebClientRequester.Post(studentServiceUrl + "students", st);

            students = WebClientRequester.Get<IEnumerable<Student>>(studentServiceUrl + "students");
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
            Console.WriteLine("---------------------------");
        }
    }
}
