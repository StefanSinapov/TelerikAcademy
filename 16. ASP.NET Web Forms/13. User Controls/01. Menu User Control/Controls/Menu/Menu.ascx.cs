namespace MenuUserControl.Controls.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    using MenuUserControl.Models;

    [System.ComponentModel.DefaultBindingProperty("DataSource")]
    public partial class Menu : UserControl
    {
        public ICollection<Link> Links { get; set; }

        public Menu()
        {
            this.FontFamily = "Comic Sans MS";
            this.FontColor = "black";
        }

        public string FontFamily { get; set; }

        public string FontColor { get; set; }

        public override void DataBind()
        {
            this.DataListLinks.DataBind();

            base.DataBind();
        }

        public IEnumerable<Link> DataSource
        {
            get
            {
                return (IEnumerable<Link>)this.DataListLinks.DataSource;
            }

            set
            {
                foreach (var item in value)
                {
                    if (string.IsNullOrWhiteSpace(item.FontColor))
                    {
                        item.FontColor = this.FontColor;
                    }
                }

                this.DataListLinks.DataSource = value;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.DataListLinks.Style.Add("font-family", this.FontFamily);
        }
    }
}