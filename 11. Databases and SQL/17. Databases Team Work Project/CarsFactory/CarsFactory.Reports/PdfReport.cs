namespace CarsFactory.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Drawing;
    using Spire.Pdf;
    using Spire.Pdf.Graphics;
    using Spire.Pdf.Grid;
    using CarsFactory.Data;
    using Data;
    using System.Globalization;

    public static class PdfReport
    {
        // verticalDistance keeps the current vertical position in the page
        private static float verticalDistanceToTheTop = 0;

        private static readonly string[] CAPTIONS = new string[] { "Product", "Quantity", "Unit Price", "Dealer", "Sum" };

        private const string TITLE = "Aggregated Sales Report";
        private const int HEIGHT_SHIFT = 20;

        public static void GeneratePdfReport(CarsFactoryContext carsFactoryContext, ReportsDataCollector collector)
        {
            PdfDocument pdfReport = InitializePdfDocument();

            SalesReportData reportData = collector.CollectDataForPdfReport(carsFactoryContext);

            PdfGrid grid = null;
            foreach (var day in reportData.DailySalesReport)
            {
                if (grid != null)
                {
                    AddGridToPage(grid, pdfReport);
                }

                DateTime date = day.Key;
                var dailyAmount = day.Value.Key;
                var records = day.Value.Value;
                records.Insert(0, CAPTIONS);

                grid = GenerateDataGrid(records, date, dailyAmount);
            }

            if (grid != null)
            {
                AddTotal("Grand Total:", reportData.GrandTotal, grid);
                AddGridToPage(grid, pdfReport);
            }

            SaveAndClose(pdfReport);
        }

        private static PdfDocument InitializePdfDocument()
        {
            PdfDocument doc = new PdfDocument();
            SetMargins();

            PdfSection section = doc.Sections.Add();
            section.PageSettings.Size = PdfPageSize.A4;
            PdfPageBase page = section.Pages.Add();

            DrawTitle(page);

            return doc;
        }

        private static PdfGrid GenerateDataGrid(List<string[]> dataSource, DateTime date, decimal dailyAmount)
        {
            PdfGrid grid = new PdfGrid();
            grid.Style.CellPadding = new PdfPaddings(3, 2, 3, 1);

            grid.Style.Font = new PdfTrueTypeFont(new Font("Arial", 10f));

            grid.DataSource = dataSource.ToArray();

            AddHeaderDateRow(grid, date);

            for (int r = 0; r < dataSource.Count; r++)
            {
                if (r == 0)
                {
                    SetHeaderRowStyle(grid.Rows[r]);
                }
                else
                {
                    if (r % 2 == 0)
                    {
                        grid.Rows[r].Style.BackgroundBrush = PdfBrushes.AliceBlue;
                    }
                }
            }

            AddTotal(String.Format("Total sum for {0:dd-MMM-yyyy}:", date), dailyAmount, grid);

            return grid;
        }

        private static void AddTotal(String description, decimal totalAmount, PdfGrid grid)
        {
            PdfGridRow totalAmountRow = grid.Rows.Add();
            totalAmountRow.Style.BackgroundBrush = PdfBrushes.Lavender;
            totalAmountRow.Style.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold));
            totalAmountRow.Cells[0].Value = description;
            totalAmountRow.Cells[0].StringFormat = new PdfStringFormat(PdfTextAlignment.Right);
            totalAmountRow.Cells[0].ColumnSpan = 4;
            totalAmountRow.Cells[4].Value = totalAmount.ToString("N", CultureInfo.InvariantCulture);
        }

        private static void AddGridToPage(PdfGrid grid, PdfDocument doc)
        {
            PdfPageBase page = doc.Sections[0].Pages[doc.Sections[0].Pages.Count - 1];

            float totalHeight = grid.Rows.Count * grid.Style.Font.Height;

            if (verticalDistanceToTheTop > (page.Canvas.ClientSize.Height - doc.PageSettings.Margins.Bottom - totalHeight))
            {
                page = doc.Sections[0].Pages.Add();
                verticalDistanceToTheTop = 0;
            }

            PdfLayoutResult result = grid.Draw(page, new PointF(2, verticalDistanceToTheTop));
            verticalDistanceToTheTop = verticalDistanceToTheTop + result.Bounds.Height + HEIGHT_SHIFT;
        }

        private static void SaveAndClose(PdfDocument doc)
        {
            doc.SaveToFile(@"..\..\..\PDF-Reports\Aggregated Sales Report.pdf");
            doc.Close();
        }

        private static void SetMargins()
        {
            PdfMargins margin = new PdfMargins();

            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();

            margin.Top = unitCvtr.ConvertUnits(1f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(2f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;
        }

        private static void DrawTitle(PdfPageBase page)
        {
            PdfBrush brush = PdfBrushes.Black;
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Arial", 14f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);
            page.Canvas.DrawString(TITLE, font, brush, page.Canvas.ClientSize.Width / 2, 0, format);

            verticalDistanceToTheTop += font.MeasureString(TITLE, format).Height + HEIGHT_SHIFT;
        }

        private static void AddHeaderDateRow(PdfGrid grid, DateTime date)
        {
            PdfGridRow headerDateRow = grid.Headers.Add(1)[0];
            headerDateRow.Cells[0].Value = String.Format("Date {0:dd-MMM-yyyy}:", date);
            headerDateRow.Cells[0].ColumnSpan = 5;
            SetHeaderRowStyle(headerDateRow);
        }

        private static void SetHeaderRowStyle(PdfGridRow row)
        {
            row.Style.BackgroundBrush = PdfBrushes.CadetBlue;
            row.Style.Font = new PdfTrueTypeFont(new Font("Arial", 11f, FontStyle.Bold), true);
        }
    }
}