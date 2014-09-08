/*
 * Using JSON.NET and the Telerik Academy Forums RSS feed implement the following:
 * 
 * 1. The RSS feed is at (http://forums.academy.telerik.com/feed/qa.rss)
 * 
 * 2. Download the content of the feed programmatically
 *    - You can use WebClient.DownloadFile()
 * 
 * 3. Parse the XML from the feed to JSON
 * 
 * 4. Using LINQ-to-JSON select all the question 
 * titles and print them to the console
 * 
 * 5. Parse the JSON string to POCO
 * 
 * 6. Using the parsed objects create a HTML 
 * page that lists all questions from the RSS their 
 * categories and a link to the question's page
 */
namespace TelerikForumRSS
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class EntryPoint
    {
        private const string RssFeedUrl = @"http://forums.academy.telerik.com/feed/qa.rss";
        private const string RssFeedFilePath = @"../../rss.xml";
        private const string HtmlPagePath = @"../../index.html";

        static void Main()
        {
            // 2. Download the content
            DownLoadRssFile(RssFeedUrl, RssFeedFilePath);

            // 3. Parse Xml Feet to Json
            var jsonRss = ParseXmlToJson();
            //Console.WriteLine(jsonRss);

            // 4. Print all titles on Console
            PrintAllTitles(jsonRss);

            // 5. Parse Json to POCO
            IEnumerable<Item> rssItems = ParseJsonToPoco(jsonRss);

            // 6. create a HTML page
            CreateHtml(rssItems);
        }

        private static void CreateHtml(IEnumerable<Item> rssItems)
        {
            Console.WriteLine("\n------- Creating HTML file -----");
            var htmlCreator = new RssToHtmlPageCreator();
            htmlCreator.CreateHtmlPage(HtmlPagePath, rssItems);
            Console.WriteLine("     -> Creating HTML Done");
        }

        private static IEnumerable<Item> ParseJsonToPoco(string jsonString)
        {
            ICollection<Item> pocoItems = new List<Item>();
            var jsonObject = JObject.Parse(jsonString);
            var items = jsonObject["rss"]["channel"]["item"];

            foreach (var item in items)
            {
                var pocoObject = JsonConvert.DeserializeObject<Item>(item.ToString());
                pocoItems.Add(pocoObject);
            }
            return pocoItems;
        }

        private static void PrintAllTitles(string jsonString)
        {
            var jsonObject = JObject.Parse(jsonString);
            var titles = jsonObject["rss"]["channel"]["item"].Select(item => item["title"]);

            Console.WriteLine("\n----------------- All titles -----------------");
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        private static string ParseXmlToJson()
        {
            if (!(File.Exists(RssFeedFilePath)))
            {
                DownLoadRssFile(RssFeedUrl, RssFeedFilePath);
            }
            var xmlRss = XDocument.Load(RssFeedFilePath);
            var jsonRss = JsonConvert.SerializeXNode(xmlRss, Formatting.Indented);
            return jsonRss;
        }

        private static void DownLoadRssFile(string url, string fileName)
        {
            Console.WriteLine("Downloading RSS File...");

            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(url, fileName);
            }

            Console.WriteLine("-> RSS Feed File was downloaded successfully");
        }
    }
}
