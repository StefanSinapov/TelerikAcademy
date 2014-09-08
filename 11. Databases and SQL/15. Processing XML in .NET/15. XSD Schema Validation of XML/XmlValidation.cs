/*
 * 15. Using Visual Studio generate an XSD 
 * schema for the file catalog.xml. 
 * Write a C# program that takes an XML file 
 * and an XSD file (schema) and validates 
 * the XML file against the schema. 
 * 
 * Test it with valid XML catalogs and invalid XML catalogs.
 */
namespace _15.XSD_Schema_Validation_of_XML
{
    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;

    class XmlValidation
    {
        private const string ValidXmlFilePath = "../../../01. XML File/catalog.xml";
        private const string InvalidXmlFilePath = "../../../01. XML File/catalog-invalid.xml";
        private const string SchemaFilePat = "../../catalog.xsd";

        static void Main()
        {
            var schemas = new XmlSchemaSet();
            schemas.Add("", XmlReader.Create(SchemaFilePat));

            var validDocument = XDocument.Load(ValidXmlFilePath);
            var invalidDocument = XDocument.Load(InvalidXmlFilePath);

            Console.WriteLine("Validating valid document: ");
            ValidateDocument(validDocument, schemas);

            Console.WriteLine("\nValidating invalid document: ");
            ValidateDocument(invalidDocument, schemas);
        }

        private static void ValidateDocument(XDocument xmlDocument, XmlSchemaSet schemas)
        {
            try
            {
                xmlDocument.Validate(schemas, (o, e) => { throw e.Exception; }, true);
                Console.WriteLine("Document is Valid");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
