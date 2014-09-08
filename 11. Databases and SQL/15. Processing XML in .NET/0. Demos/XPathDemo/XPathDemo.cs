using System;
using System.Xml;

class XPathDemo
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../items.xml");
        string xPathQuery = "/items/item[@type='beer']";
        
        XmlNodeList beersList = xmlDoc.SelectNodes(xPathQuery);
        foreach (XmlNode beerNode in beersList)
        {
            string beerName = beerNode.SelectSingleNode("name").InnerText;
            Console.WriteLine(beerName);
        }
    }
}
