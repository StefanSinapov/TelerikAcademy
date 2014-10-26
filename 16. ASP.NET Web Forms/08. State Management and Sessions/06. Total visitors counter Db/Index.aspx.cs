namespace VisitorsCounter
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;

    using VisitorsCounter.Data;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = new VisitorsDbContext();

            data.Visitors.Add(new Visitor());
            data.SaveChanges();

            var count = data.Visitors.Count();

            var generatedImage = new Bitmap(110, 110);
            using (generatedImage)
            {
                Graphics gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    gr.FillRectangle(Brushes.Black, 0, 0, 200, 200);

                    gr.DrawString(
                        count.ToString(CultureInfo.InvariantCulture),
                        new Font("Segoe UI", 40),
                        new SolidBrush(Color.LawnGreen),
                         new PointF(20, 15));

                    // Set response header and write the image into response stream
                    Response.ContentType = "image/jpeg";

                    // Response.AppendHeader("Content-Disposition",
                    // "attachment; filename=\"Financial-Report-April-2013.gif\"");
                    generatedImage.Save(Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}