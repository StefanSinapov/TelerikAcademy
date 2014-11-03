namespace MenuUserControl
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    using MenuUserControl.Models;

    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var links = new HashSet<Link>
                        {
                            new Link { Title = "Google", Url = "http://www.google.com", FontColor = "red"},
                            new Link { Title = "Telerik Academy", Url = "http://www.telerikacademy.com", FontColor = "Yellowgreen"},
                            new Link { Title = "Facebook", Url = "http://www.facebook.com", FontColor = "blue"},
                            new Link { Title = "YouTube", Url = "http://www.youtube.com", FontColor = "Red" },
                            new Link { Title = "GitHub", Url = "http://www.github.com" }
                        };

            this.MenuAside.DataSource = links;
            this.MenuAside.DataBind();

            this.MenuCustomFont.DataSource = links;
            this.MenuCustomFont.DataBind();
        }
    }
}