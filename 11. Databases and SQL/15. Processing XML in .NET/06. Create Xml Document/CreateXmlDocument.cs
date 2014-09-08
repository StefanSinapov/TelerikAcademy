/*
 * 6. In a text file we are given the name, 
 * address and phone number of given person 
 * (each at a single line).
 * Write a program, which creates new XML document, 
 * which contains these data in structured XML format.
 */
namespace _06.Create_Xml_Document
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    class CreateXmlDocument
    {
        private const string FilePath = "../../../output/person.xml";

        private static readonly string personData = 
@"John Nash
bul. Bulgaria
0899 819384
";

        static void Main()
        {
            Console.SetIn(new StringReader(personData));

            var name = Console.ReadLine();
            var address = Console.ReadLine();
            var phone = Console.ReadLine();

            var personXml = new XElement("person",
                new XElement("name", name),
                new XElement("address", address),
                new XElement("phone", phone));

            personXml.Save(FilePath);
            Console.WriteLine("file saved at: {0}", FilePath);
        }
    }
}
