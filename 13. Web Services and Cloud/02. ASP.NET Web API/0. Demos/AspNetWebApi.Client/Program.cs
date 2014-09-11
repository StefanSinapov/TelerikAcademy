namespace AspNetWebApi.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:28670/") };

        internal static void Main()
        {
            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            /*
             * The GetAsync method sends an HTTP GET request. As the name implies, GetAsyc is asynchronous.
             * It returns immediately, without waiting for a response from the server.
             * The return value is a Task object that represents the asynchronous operation.
             * When the operation completes, the Task.Result property contains the HTTP response.
             */
            HttpResponseMessage response = Client.GetAsync("api/posts").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<IEnumerable<Post>>().Result;
                foreach (var p in products)
                {
                    Console.WriteLine("{0,4} {1,-20} {2}", p.Id, p.Title, p.CreatedOn);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddNewPost(string title, string content)
        {
            var post = new Post { Title = title, Content = content };

            var response = Client.PostAsJsonAsync("api/posts", post).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
