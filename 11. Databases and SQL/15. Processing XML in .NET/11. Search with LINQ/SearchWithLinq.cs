/*
 * Rewrite the previous using LINQ query.
 */
namespace _11.Search_with_LINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    class SearchWithLinq
    {
        private const string FilePath = "../../../01. XML File/catalog.xml";

        static void Main()
        {
            var xDoc = XDocument.Load(FilePath);

            var albums = xDoc.Descendants("year")
                .Where(y => String.Compare(y.Value, "2009", StringComparison.InvariantCulture) <= 0)
                .Select(y => y.Parent);

            foreach (XElement album in albums)
            {
                string albumName = album.XPathSelectElement("name").Value;
                string year = album.XPathSelectElement("year").Value;
                string price = album.XPathSelectElement("price").Value;
                Console.WriteLine("{0} - Year: {1} - Price: {2}", albumName, year, price);
            }
        }
    }
}
