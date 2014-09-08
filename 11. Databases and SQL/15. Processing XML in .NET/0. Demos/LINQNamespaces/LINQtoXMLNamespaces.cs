using System.Linq;
using System.Xml.Linq;

class LINQtoXMLNamespaces
{
    static void Main(string[] args)
    {
        XNamespace ns = "http://linqinaction.net";
        XNamespace anotherNS = "http://publishers.org";

        XElement booksXml = new XElement(
            XName.Get("books", "http://bookstore.org"));
        XElement bookLINQ = new XElement(ns + "book",
            new XElement(ns + "title", "LINQ in Action"),
            new XElement(ns + "author", "Manning"),
            new XElement(ns + "author", "Steve Eichert"),
            new XElement(ns + "author", "Jim Wooley"),
            new XElement(anotherNS + "publisher", "Manning")
        );
        booksXml.Add(bookLINQ);

        XElement bookSilverlight = new XElement(ns + "book",
            new XElement(ns + "title", "Silverlight in Action"),
            new XElement(ns + "author", "Pete Brown"),
            new XElement(anotherNS + "publisher", "Manning")
        );
        booksXml.Add(bookSilverlight);

        System.Console.WriteLine(booksXml);

        booksXml.Save("../../books.xml");
    }
}
