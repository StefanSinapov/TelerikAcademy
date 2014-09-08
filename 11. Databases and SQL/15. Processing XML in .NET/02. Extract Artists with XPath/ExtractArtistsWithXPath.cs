/*
 * 2. Implement the previous using XPath.
 */
namespace _02.Extract_Artists_with_XPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class ExtractArtistsWithXPath
    {
        private const string FilePath = "../../../01. XML File/catalog.xml";

        static void Main()
        {
            var artists = new Dictionary<string, int>();
            var doc = new XmlDocument();
            doc.Load(FilePath);

            string artistXPathQuery = "//album";

            XmlNodeList albumNodeList = doc.SelectNodes(artistXPathQuery);

            foreach (XmlNode artistNode in albumNodeList)
            {
                string artistName = artistNode.SelectSingleNode("artist").InnerText;
                int songsCount = artistNode.SelectSingleNode("songs").ChildNodes.Count;
                if (!artists.ContainsKey(artistName))
                {
                    artists.Add(artistName, 0);
                }

                artists[artistName] += songsCount;
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("{0}: {1} songs", artist.Key, artist.Value);
            }
        }
    }
}
