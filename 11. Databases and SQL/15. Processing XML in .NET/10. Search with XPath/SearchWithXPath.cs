/*
 * 10. Write a program, which extract from the
 * file catalog.xml the prices for all albums, 
 * published 5 years ago or earlier. 
 * 
 * Use XPath query.
 */
namespace _10.Search_with_XPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class SearchWithXPath
    {
        private const string FilePath = "../../../01. XML File/catalog.xml";

        static void Main()
        {
            var artists = new Dictionary<string, int>();
            var doc = new XmlDocument();
            doc.Load(FilePath);

            string albumsYearXPathQuery = "//album/year[.<=2009]";

            XmlNodeList albumNodeList = doc.SelectNodes(albumsYearXPathQuery);

            foreach (XmlNode yearNode in albumNodeList)
            {
                string albumName = yearNode.ParentNode.FirstChild.InnerText;
                string year = yearNode.InnerText;
                string price = yearNode.NextSibling.NextSibling.InnerText;
                Console.WriteLine("{0} - Year: {1} - Price: {2}", albumName, year, price);
            }
        }
    }
}
