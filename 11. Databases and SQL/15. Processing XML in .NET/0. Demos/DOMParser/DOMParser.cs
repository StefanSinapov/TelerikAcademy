using System;
using System.Xml;

class DOMParser
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("../../library.xml");
        Console.WriteLine("Loaded XML document:");
        Console.WriteLine(doc.OuterXml);
        Console.WriteLine();

        XmlNode rootNode = doc.DocumentElement;
        Console.WriteLine("Root node: {0}", rootNode.Name);

        foreach (XmlAttribute atr in rootNode.Attributes)
        {
            Console.WriteLine("Attribute: {0}={1}",
                atr.Name, atr.Value);
        }
        Console.WriteLine();

        foreach (XmlNode node in rootNode.ChildNodes)
        {
            Console.WriteLine("Book title = {0}",
                node["title"].InnerText);
            Console.WriteLine("Book author = {0}",
                node["author"].InnerText);
            Console.WriteLine("Book isbn = {0}",
                node["isbn"].InnerText);
            Console.WriteLine();
        }
    }
}
