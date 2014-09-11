using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UsingWebClient.Models
{
    class WebClientRequester
    {
        public static void Get(string resourceUrl)
        {
            var webClient = new WebClient();
            webClient.DownloadString(resourceUrl);
        }

        public static T Get<T>(string resourceUrl)
        {
            var webClient = new WebClient();
            var jsonData = webClient.DownloadString(resourceUrl);
            var data = JsonConvert.DeserializeObject<T>(jsonData);
            return data;
        }

        public static void Post(string resourceUrl, object data)
        {
            var requestData = JsonConvert.SerializeObject(data);
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString(resourceUrl, requestData);
        }

        public static T Post<T>(string resourceUrl, object data)
        {
            var requestData = JsonConvert.SerializeObject(data);
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var responseString = client.UploadString(resourceUrl, requestData);
            var responseData = JsonConvert.DeserializeObject<T>(responseString);
            return responseData;
        }

        public static void Delete(string resourceUrl)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString(resourceUrl, "DELETE", "");
        }
    }
}