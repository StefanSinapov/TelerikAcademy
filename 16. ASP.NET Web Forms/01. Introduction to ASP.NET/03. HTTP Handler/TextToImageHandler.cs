namespace _03.HTTP_Handler
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Web;

    public class TextToImageHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var requestUrl = context.Request.Url;
            var path = context.Server.MapPath("Data/blank.png");
            var bitmap = new Bitmap(path);
            var graphics = Graphics.FromImage(bitmap);
            var brush = new SolidBrush(Color.White);

            graphics.FillRectangle(brush, 0, 0, 5000, 150);
            graphics.DrawString(
                requestUrl.ToString().Substring(23),
                new Font("Segoe UI", 25),
                new SolidBrush(Color.Black),
                new PointF(25, 40));
            context.Response.ContentType = "image/png";
            bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
        }
    }
}