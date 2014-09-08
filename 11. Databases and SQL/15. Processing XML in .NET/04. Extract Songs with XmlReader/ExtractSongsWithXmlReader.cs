/*
 * 4. Write a program, which using XmlReader extracts 
 * all song titles from catalog.xml.
 */
namespace _04.Extract_Songs_with_XmlReader
{
    using System;
    using System.Xml;

    class ExtractSongsWithXmlReader
    {
        private const string FilePath = "../../../01. XML File/catalog.xml";

        static void Main()
        {
            Console.WriteLine("All song titles: ");
         
            using (XmlReader reader = XmlReader.Create(FilePath))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }

        }
    }
}
