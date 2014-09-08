namespace RobotsFactory.XML
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using RobotsFactory.Common;
    using RobotsFactory.Reports.Models;

    public class XmlReportGenerator
    {
        private const string DateTimeFormatInXml = "dd-MMM-yyyy";
        private const string EncodingType = "utf-8";

        private readonly IQueryable<IGrouping<string, XmlSaleReport>> saleReportsData;

        public XmlReportGenerator(IQueryable<XmlSaleReport> saleReportsData)
        {
            this.saleReportsData = saleReportsData.GroupBy(m => m.ManufacturerName);
        }

        public void CreateXmlReport(string pathToSave, string xmlReportName, DateTime startDate, DateTime endDate)
        {
            var encoding = Encoding.GetEncoding(EncodingType);

            if (!string.IsNullOrEmpty(xmlReportName))
            {
                Utility.CreateDirectoryIfNotExists(pathToSave);
            }

            using (var writer = new XmlTextWriter(pathToSave + xmlReportName, encoding))
            {
                this.SetHeader(writer);

                foreach (var manufacturer in this.saleReportsData.Select(a => new { Name = a.Key, Reports = a.GroupBy(b => b.ReportDate) }))
                {
                    this.SetTitle(writer, manufacturer.Name);

                    foreach (var report in manufacturer.Reports)
                    {
                        this.WriteSummaryToSale(writer, report.Key, report.Sum(s => s.Sum));
                    }

                    writer.WriteEndElement();
                }
            }
        }
 
        private void SetHeader(XmlTextWriter writer)
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;

            writer.WriteStartDocument();
            writer.WriteStartElement("sales");
            writer.WriteAttributeString("name", "Sales Report");
        }
 
        private void SetTitle(XmlTextWriter writer, string vendorName)
        {
            writer.WriteStartElement("sale");
            writer.WriteAttributeString("vendor", vendorName);
        }
 
        private void WriteSummaryToSale(XmlTextWriter writer, DateTime date, decimal totalSum)
        {
            writer.WriteStartElement("summary");
            writer.WriteAttributeString("date", date.ToString(DateTimeFormatInXml));
            writer.WriteAttributeString("total-sum", totalSum.ToString());
            writer.WriteEndElement();
        }
    }
}