/*
 * Rewrite the same using XDocument and LINQ query.
 */
namespace _05.Extract_Songs_with_Linq_to_Xml
{
    using System;
    using System.Xml.Linq;

    class ExtractSongsWithLinq
    {
        private const string FilePath = "../../../01. XML File/catalog.xml";

        static void Main()
        {
            var doc = XDocument.Load(FilePath);

            foreach (var title in doc.Descendants("title"))
            {
                Console.WriteLine(title.Value);
            }
        }
    }
}
