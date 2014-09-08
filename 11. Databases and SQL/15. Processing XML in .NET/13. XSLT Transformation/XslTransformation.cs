/*
 * 13. Write a C# program to apply the XSLT 
 * stylesheet transformation on the file 
 * catalog.xml using the class XslTransform.
 */
namespace _13.XSLT_Transformation
{
    using System;
    using System.Xml.Xsl;

    class XslTransformation
    {
        private const string XmlFilePath = "../../../01. XML File/catalog.xml";
        private const string XslFilePath = "../../../12. XSLT File/catalog.xslt";
        private const string OutputFilePath = "../../../output/catalog.html";

        static void Main()
        {

            try
            {
                var xslt = new XslCompiledTransform();
                xslt.Load(XslFilePath);
                xslt.Transform(XmlFilePath, OutputFilePath);
                Console.WriteLine("File successfully created at {0}", OutputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
