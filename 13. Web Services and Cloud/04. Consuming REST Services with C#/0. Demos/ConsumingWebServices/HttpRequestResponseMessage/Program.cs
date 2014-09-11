using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HttpRequestResponseMessage.Models;

namespace HttpRequestResponseMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseUrl = "http://localhost:7232/";
            var requester = new HttpRequester(baseUrl);

            var newStudent = new Student()
            {
                FirstName = "Nikolay 2",
                LastName = "Kostov 2"
            };

            var createStudentTask =
                requester.PostAsync<Student>("api/students", newStudent);
            createStudentTask.GetAwaiter()
                             .OnCompleted(() =>
                             {
                                 Console.WriteLine("Student {0} created!", createStudentTask.Result.FullName);
                                 var students = requester.Get<IEnumerable<Student>>("api/students");
                                 foreach (var student in students)
                                 {
                                     Console.WriteLine(student.FullName);
                                 }
                             });
            while (true)
            {
                Console.ReadLine();
            }
        }

        class HttpRequester
        {
            private string baseUrl;
            private HttpClient client;

            public HttpRequester(string baseUrl)
            {
                this.baseUrl = baseUrl;
                this.client = new HttpClient();
            }

            public T Get<T>(string serviceUrl, string mediaType = "application/json")
            {
                var request = new HttpRequestMessage();

                request.RequestUri = new Uri(this.baseUrl + serviceUrl);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                request.Method = HttpMethod.Get;

                var response = client.SendAsync(request).Result;

                var returnObj = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(returnObj);
            }

            public T Post<T>(string serviceUrl, object data, string mediaType = "application/json")
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(this.baseUrl + serviceUrl);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                request.Method = HttpMethod.Post;

                request.Content = new StringContent(JsonConvert.SerializeObject(data));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

                var response = client.SendAsync(request).Result;
                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }

            public Task<T> CreateGetRequestAsync<T>(string serviceUrl, string mediaType = "application/json")
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(this.baseUrl + serviceUrl);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                request.Method = HttpMethod.Get;

                return client.SendAsync(request).ContinueWith(
                    (task) =>
                    {
                        var response = task.Result;
                        var content = response.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<T>(content);
                        return result;
                    });
            }

            public Task<T> PostAsync<T>(string serviceUrl,
                object data, string mediaType = "application/json")
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(this.baseUrl + serviceUrl);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                request.Method = HttpMethod.Post;

                request.Content = new StringContent(JsonConvert.SerializeObject(data));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

                return client.SendAsync(request).ContinueWith((task) =>
                {
                    var response = task.Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<T>(content);
                    return result;
                });
            }

            public Task PostAsync(string serviceUrl,
                object data, string mediaType = "application/json")
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(this.baseUrl + serviceUrl);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                request.Method = HttpMethod.Post;

                request.Content = new StringContent(JsonConvert.SerializeObject(data));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

                return client.SendAsync(request);
            }
        }
    }
}