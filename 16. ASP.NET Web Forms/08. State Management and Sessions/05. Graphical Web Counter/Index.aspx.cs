namespace GraphicWebCounter
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Web.UI;

    public partial class Index : Page
    {
        public int? Visitors
        {
            get
            {
                return (int)this.Application["visitors"];
            }
            
            set
            {
                this.Application["visitors"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Application["visitors"] == null)
            {
                this.Visitors = 0;
            }

            this.Visitors++;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var generatedImage = new Bitmap(110, 110);
            using (generatedImage)
            {
                Graphics gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    gr.FillRectangle(Brushes.Black, 0, 0, 200, 200);

                    gr.DrawString(
                        this.Visitors.ToString(),
                        new Font("Segoe UI", 40),
                        new SolidBrush(Color.GreenYellow),
                         new PointF(20, 10));

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