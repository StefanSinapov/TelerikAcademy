namespace HTMLEscapingText
{
    using System;
    using System.Web.UI;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonShowText_OnClick(object sender, EventArgs e)
        {
            var enteredText = Server.HtmlEncode(this.TextBoxInput.Text);
            this.TextBoxOutput.Text = enteredText;
            this.LabelOutput.Text = enteredText;
        }
    }
}