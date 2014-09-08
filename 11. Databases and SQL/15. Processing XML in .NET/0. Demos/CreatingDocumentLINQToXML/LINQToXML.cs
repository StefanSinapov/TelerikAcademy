using System.Xml.Linq;

class CreatingDocumentLINQToXML
{
    static void Main()
    {
        XElement booksXml = new XElement("books",
            new XElement("book",
                new XElement("author", "Don Box"),
                new XElement("title", "ASP.NET")
            ),
            new XElement("book",
                new XElement("author", "Svetlin Nakov and his team"),
                new XElement("title", "Introduction to Programming with C#")
            )
        );

        System.Console.WriteLine(booksXml);

        booksXml.Save("../../books.xml");           
    }
}
