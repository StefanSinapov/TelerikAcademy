## 16. Json in .NET

Using JSON.NET and the Telerik Academy Forums RSS feed implement the following:
1. The RSS feed is at [http://forums.academy.telerik.com/feed/qa.rss](http://forums.academy.telerik.com/feed/qa.rss)
2. Download the content of the feed programmatically
	- You can use WebClient.DownloadFile()
3. Parse the XML from the feed to JSON
4. Using LINQ-to-JSON select all the question titles and print them to the console
5. Parse the JSON string to POCO
6. Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question's page
