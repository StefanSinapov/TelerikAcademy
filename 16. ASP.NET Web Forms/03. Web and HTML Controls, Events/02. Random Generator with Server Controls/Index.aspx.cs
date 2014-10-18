namespace WebRandomGenerator
{
    using System;
    using System.Web.UI;

    public partial class Index : Page
    {
        private readonly Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GenerateRandom(object sender, EventArgs e)
        {
            var firstNumber = int.Parse(this.tbFirstNumber.Text);
            var secondNumber = int.Parse(this.tbSecondNumber.Text);
            this.lbResult.Text = "Your random number is: " + this.random.Next(firstNumber, secondNumber + 1);
        }
    }
}