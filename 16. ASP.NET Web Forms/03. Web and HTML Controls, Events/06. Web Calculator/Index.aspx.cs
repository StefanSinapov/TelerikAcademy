namespace WebCalculator
{
    using System;
    using System.Globalization;
    using System.Web.UI;

    public partial class Index : Page
    {
        private bool plus = false;
        private bool minus = false;
        private bool multiply = false;
        private bool divide = false;
        private bool sqrt = false;

        public string Prev { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonOneClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "1";
        }

        protected void ButtonTwoClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "2";
        }

        protected void ButtonThreeClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "3";
        }

        protected void ButtonPlusClick(object sender, EventArgs e)
        {
            if (this.TextBoxCalc.Text == string.Empty)
            {
                return;
            }

            this.plus = true;
            this.Prev = this.TextBoxCalc.Text;
            this.TextBoxCalc.Text = string.Empty;
        }

        protected void ButtonFourClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "4";
        }

        protected void ButtonFiveClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "5";
        }

        protected void ButtonSixClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "6";
        }

        protected void ButtonMinusClick(object sender, EventArgs e)
        {
            if (this.TextBoxCalc.Text == string.Empty)
            {
                return;
            }

            this.minus = true;
            this.Prev = this.TextBoxCalc.Text;
            this.TextBoxCalc.Text = string.Empty;
        }

        protected void ButtonSevenClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "7";
        }

        protected void ButtonEightClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "8";
        }

        protected void ButtonNineClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "9";
        }

        protected void ButtonMultiplyClick(object sender, EventArgs e)
        {
            if (this.TextBoxCalc.Text == string.Empty)
            {
                return;
            }

            this.multiply = true;
            this.Prev = this.TextBoxCalc.Text;
            this.TextBoxCalc.Text = string.Empty;
        }

        protected void ButtonClearClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = string.Empty;
        }

        protected void ButtonZeroClick(object sender, EventArgs e)
        {
            this.TextBoxCalc.Text = this.TextBoxCalc.Text + "0";
        }

        protected void ButtonDivideClick(object sender, EventArgs e)
        {
            if (this.TextBoxCalc.Text == string.Empty)
            {
                return;
            }

            this.divide = true;
            this.Prev = this.TextBoxCalc.Text;
            this.TextBoxCalc.Text = string.Empty;
        }

        protected void ButtonSqrtClick(object sender, EventArgs e)
        {
            if (this.TextBoxCalc.Text == string.Empty)
            {
                return;
            }

            this.sqrt = true;
            this.Prev = this.TextBoxCalc.Text;
            this.TextBoxCalc.Text = string.Empty;
        }

        protected void ButtonDotClick(object sender, EventArgs e)
        {
            if (this.TextBoxCalc.Text.Contains("."))
            {
            }
            else
            {
                this.TextBoxCalc.Text += ".";
            }
        }

        protected void ButtonEqualsClick(object sender, EventArgs e)
        {
            if (this.plus)
            {
                decimal dec = Convert.ToDecimal(this.Prev) + Convert.ToDecimal(this.TextBoxCalc.Text);
                this.TextBoxCalc.Text = dec.ToString(CultureInfo.InvariantCulture);
            }
            else if (this.minus)
            {
                decimal dec = Convert.ToDecimal(this.Prev) - Convert.ToDecimal(this.TextBoxCalc.Text);
                this.TextBoxCalc.Text = dec.ToString(CultureInfo.InvariantCulture);
            }
            else if (this.multiply)
            {
                decimal dec = Convert.ToDecimal(this.Prev) * Convert.ToDecimal(this.TextBoxCalc.Text);
                this.TextBoxCalc.Text = dec.ToString(CultureInfo.InvariantCulture);
            }
            else if (this.divide)
            {
                decimal dec = Convert.ToDecimal(this.Prev) / Convert.ToDecimal(this.TextBoxCalc.Text);
                this.TextBoxCalc.Text = dec.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}