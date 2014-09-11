using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpClient
{
    class Program
    {
        static async void PrintStudents(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync("students");
            //Some code to simulate a slow request
            System.Threading.Thread.Sleep(3000);
            //end of slowing code

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        static async void CreateStudent(HttpClient httpClient, Student theStudent)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(theStudent));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("students", postContent);
            //Some code to simulate a slow request
            System.Threading.Thread.Sleep(3000);
            //end of slowing code

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Student created!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error creating student");
            }
        }

        static void Main(string[] args)
        {
            //Note: To use HttpClient the project has to be targeting .NET 4.5 and needs an added reference to System.Net.Http 4.0
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:7232/api/");

            PrintStudents(httpClient);
            Console.WriteLine("Press Enter to create student");
            Console.ReadLine();
            CreateStudent(httpClient, new Student() { FirstName = "John", LastName = "Snow" });
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }

    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
