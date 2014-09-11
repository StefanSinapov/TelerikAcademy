using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SimpleWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();

            var students = client.DownloadString("http://localhost:7232/api/students");

            Console.WriteLine(students);

            //Equivalent of POST request. Note: Don't forget the content type
            var studentToPost = "{'FirstName': 'Hitar', 'LastName': 'Petar'}";
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString("http://localhost:7232/api/students", studentToPost);

            students = client.DownloadString("http://localhost:7232/api/students");

            Console.WriteLine(students);
        }
    }
}
