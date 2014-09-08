using System;
using System.Xml;
using System.Globalization;

class ModifyXMLwithDOM
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("../../items.xml");

        string culture = doc.DocumentElement.Attributes["culture"].Value;
        CultureInfo numberFormat = new CultureInfo(culture);

        // Promotion: decrease twice the price of all beers
        foreach (XmlNode node in doc.DocumentElement)
        {
            if (node.Attributes["type"].Value == "beer")
            {
                string currentPriceStr = node["price"].InnerText;
                decimal currentPrice = Decimal.Parse(currentPriceStr, numberFormat);
                decimal newPrice = currentPrice / 2;
                node["price"].InnerText = newPrice.ToString(numberFormat);
            }
        }

        Console.WriteLine("Modified XML document:");
        Console.WriteLine(doc.OuterXml);

        doc.Save("../../itemsNew.xml");
    }
}
