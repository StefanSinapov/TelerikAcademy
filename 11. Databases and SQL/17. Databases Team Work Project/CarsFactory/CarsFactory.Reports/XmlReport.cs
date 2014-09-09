namespace CarsFactory.Reports
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;

    using CarsFactory.Data;
    using Data;
    using CarsFactory.Models;

    public class XmlReport
    {
        public static void GenerateXmlReports(CarsFactoryContext context, ReportsDataCollector collector)
        {
            string xmlReportPath = @"..\..\..\Xml-Reports\Sales-by-Dealers-report.xml";
            Encoding encoding = Encoding.GetEncoding("utf-8");

            var dealers = collector.CollectDataForXmlReport(context);

            using (XmlTextWriter writer = new XmlTextWriter(xmlReportPath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("sales");

                foreach (var record in dealers)
                {
                    var dealerName = record.Key;
                    WriteSale(writer, dealerName);

                    foreach (var saleReport in record.Value)
                    {
                        var reportDate = saleReport.ReportDate.ToString();
                        var totalSum = saleReport.TotalSum.ToString();

                        WriteSaleElements(writer, reportDate, totalSum);
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }
        }

        private static void WriteSale(XmlWriter writer, string dealerName)
        {
            writer.WriteStartElement("sale");
            writer.WriteAttributeString("dealer", dealerName);
        }

        private static void WriteSaleElements(XmlWriter writer, string reportDate, string totalSum)
        {
            writer.WriteStartElement("summary");
            writer.WriteAttributeString("report-date", reportDate);
            writer.WriteAttributeString("total-sum", totalSum);
            writer.WriteEndElement();
        }
    }
}
