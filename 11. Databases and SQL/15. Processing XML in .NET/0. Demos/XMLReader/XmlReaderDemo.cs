using System;
using System.Xml;

class XmlReaderDemo
{
    static void Main()
    {
        Console.WriteLine("Book titles in the library:");
        using (XmlReader reader = XmlReader.Create("../../library.xml"))
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
        Console.WriteLine("\nElement names in the XML file:");
        using (XmlReader reader = XmlReader.Create("../../library.xml"))
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine(reader.Name);
                }
            }
        }
    }
}
