/*
 * 3. Using the DOM parser write a program to
 * delete from catalog.xml all albums having price > 20.
 */
namespace _03.Delete_node_with_Dom_parser
{
    using System;
    using System.Xml;

    class DeleteNodeWithDomParser
    {
        private const string FilePath = "../../../01. XML File/catalog.xml";
        private const string FilePathToSave = "../../../01. XML File/catalog-deleted.xml";

        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load(FilePath);

            int counter = 0;
            string xPathQuery = "/albums/album/price";
            XmlNodeList nodesList = doc.SelectNodes(xPathQuery);

            foreach (XmlNode node in nodesList)
            {
                if (double.Parse(node.InnerText) > 20)
                {
                    node.ParentNode.ParentNode.RemoveChild(node.ParentNode);
                    counter++;
                }
            }
            Console.WriteLine("{0} albums were deleted", counter);
            doc.Save(FilePathToSave);
        }
    }
}
