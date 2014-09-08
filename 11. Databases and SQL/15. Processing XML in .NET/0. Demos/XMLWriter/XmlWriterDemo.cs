using System;
using System.Xml;
using System.Text;

class XmlWriterDemo
{
    public static void Main()
    {
        string fileName = "../../books.xml";
        Encoding encoding = Encoding.GetEncoding("windows-1251");
        using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;
        
            writer.WriteStartDocument();
            writer.WriteStartElement("library");
            writer.WriteAttributeString("name", "My Library");
            WriteBook(writer, "Code Complete",
                "Steve McConnell", "155-615-484-4");
            WriteBook(writer, "Въведение в програмирането със C#",
                "Светлин Наков и колектив", "954-775-305-3");
            WriteBook(writer, "Writing Solid Code",
                "Steve Maguire", "155-615-551-4");
            writer.WriteEndDocument();
        }
        Console.WriteLine("Document {0} created.", fileName);
    }

    private static void WriteBook(XmlWriter writer, string title, string author, string isbn)
    {
        writer.WriteStartElement("book");
        writer.WriteElementString("title", title);
        writer.WriteElementString("author", author);
        writer.WriteElementString("isbn", isbn);
        writer.WriteEndElement();
    }
}
