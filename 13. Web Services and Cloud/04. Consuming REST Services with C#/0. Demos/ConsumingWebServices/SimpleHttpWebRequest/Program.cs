using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpWebRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = WebRequest.Create("http://localhost:7232/api/students") as HttpWebRequest;

            request.ContentType = "application/json";
            request.Method = "GET";

            var response = request.GetResponse();

            var responseReader = new StreamReader(response.GetResponseStream());

            Console.WriteLine(responseReader.ReadToEnd());

            responseReader.Close();
        }
    }
}
