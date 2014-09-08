using System;
using System.Linq;
using System.Xml.Linq;

class SearchingWithLINQ
{
    static void Main()
    {
        XDocument xmlDoc = XDocument.Load("../../books.xml");
        var books =
            from book in xmlDoc.Descendants("book")
            where book.Element("title").Value.Contains("4.0")
            select new
            {
                Title = book.Element("title").Value,
                Author = book.Element("author").Value
            };
        Console.WriteLine("Found {0} books:", books.Count());
        foreach (var book in books)
        {
            Console.WriteLine(" - {0} (by {1})", book.Title, book.Author);
        }
    }
}
