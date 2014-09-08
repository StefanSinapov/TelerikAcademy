using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace XPathNavigatorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../items.xml");

            XPathNavigator nav = xmlDoc.CreateNavigator();

            string xPathQuery = "/items/item[@type='beer']/price";
            XPathNodeIterator iter = nav.Select(xPathQuery);

            while (iter.MoveNext())
            {
                iter.Current.InnerXml = "0";
            }

            xmlDoc.Save("../../itemsNew.xml");
        }
    }
}
