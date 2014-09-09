namespace CarsFactory.Reports.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SalesReportData
    {
        public SalesReportData(decimal grandTotoal, Dictionary<DateTime, KeyValuePair<decimal, List<string[]>>> dailySalesReport )
        {
            this.GrandTotal = grandTotoal;
            this.DailySalesReport = dailySalesReport;
        } 
        
        public decimal GrandTotal { get; private set;}
        public Dictionary<DateTime, KeyValuePair<decimal, List<string[]>>> DailySalesReport {get;  private set;}
    }
}