using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace WebClientSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();

            //Equivalent of GET request
            var students = client.DownloadString("http://localhost:7232/api/students");

            Console.WriteLine(students);
            
            //We can make such a request to any URL:
            //var academyHtml = client.DownloadString("http://academy.telerik.com");
            //Console.WriteLine(academyHtml);

            //Equivalent of POST request. Note: Don't forget the content type
            var studentToPost = "{'FirstName': 'Hitar', 'LastName': 'Petar'}";
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString("http://localhost:7232/api/students", studentToPost);

            //Downloading the students to see the change
            students = client.DownloadString("http://localhost:7232/api/students");

            Console.WriteLine(students);
        }
    }
}
