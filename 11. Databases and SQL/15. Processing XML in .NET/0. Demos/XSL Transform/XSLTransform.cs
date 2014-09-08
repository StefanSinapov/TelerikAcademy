using System.Xml.Xsl;

class XSLTransform
{
    static void Main()
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load("../../catalog.xsl");
        xslt.Transform("../../catalog.xml", "../../catalog.html");
    }
}
