namespace ValidationControls
{
    using System;
    using System.Web.UI;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonRegister_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LabelMessage.Text = "The page is valid!";
            }

            this.LabelMessage.Visible = Page.IsValid;
        }
    }
}