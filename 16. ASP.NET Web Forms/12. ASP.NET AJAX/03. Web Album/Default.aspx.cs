namespace WebAlbum
{
    using System;
    using System.Web.UI;

    public partial class Default : Page
    {
        [System.Web.Services.WebMethod]
         public static AjaxControlToolkit.Slide[] GetSlides()
        {
            var imgSlide = new AjaxControlToolkit.Slide[4];

            imgSlide[1] = new AjaxControlToolkit.Slide("images/jon-snow.jpg", "jon", "Jon snow");
            imgSlide[2] = new AjaxControlToolkit.Slide("images/arya-stark.jpg", "arya", "Arya Stark");
            imgSlide[0] = new AjaxControlToolkit.Slide("images/daenerys.jpg", "daenerys", "Daenerys Targaryen");
            imgSlide[3] = new AjaxControlToolkit.Slide("images/tyrion.jpg", "Tyrion", "Tyrion Lannister");

            return imgSlide;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
       
    }
}