/*
 * 7. Write a program, which (using XmlReader and XmlWriter) 
 * reads the file catalog.xml and creates the file album.xml, 
 * in which stores in appropriate way the names of all albums 
 * and their authors.
 */
namespace _07.Create_Xml_with_Streaming_Parser
{
    using System.Text;
    using System.Xml;

    class CreateXmlWithStreaming
    {
        private const string InputFilePath = "../../../01. XML File/catalog.xml";
        private const string OutputFilePath = "../../../output/album.xml";

        static void Main()
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (var writer = new XmlTextWriter(OutputFilePath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                using (XmlReader reader = XmlReader.Create(InputFilePath))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "album"))
                        {
                            writer.WriteStartElement("album");
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "name"))
                        {
                            writer.WriteElementString("name", reader.ReadElementString());
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "artist"))
                        {
                            writer.WriteElementString("artist", reader.ReadElementString());
                        }

                        if ((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "album"))
                        {
                            writer.WriteEndElement();
                        }
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
