namespace SessionStorage
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    public partial class Index : Page
    {
        public List<string> Output
        {
            get
            {
                return (List<string>)this.Session["Output"];
            }

            set
            {
                this.Session["Output"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Output == null)
            {
                this.Output = new List<string>();
            }
            else
            {
                this.LabelOutput.Text = string.Empty;
                foreach (var input in this.Output)
                {
                    this.LabelOutput.Text += input + "<hr/>";
                }
            }
        }

        protected void ButtonSubmit_OnClick(object sender, EventArgs e)
        {
            this.Output.Add(this.TextBoxInput.Text);

            this.LabelOutput.Text = string.Empty;
            this.TextBoxInput.Text = string.Empty;
            foreach (var input in this.Output)
            {
                this.LabelOutput.Text += input + "<hr/>";
            }
        }
    }
}