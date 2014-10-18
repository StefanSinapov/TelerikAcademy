namespace WebRandomGenerator
{
    using System;
    using System.Globalization;

    public partial class Index : System.Web.UI.Page
    {
        private readonly Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GenerateRandom(object sender, EventArgs e)
        {
            var firstNumber = int.Parse(this.inputFirstNumber.Value);
            var secondNumber = int.Parse(this.inputSecondNumber.Value);
            this.randomResult.InnerText = "Your random number is: " + 
                this.random.Next(firstNumber, secondNumber + 1).ToString(CultureInfo.InvariantCulture);
        }
    }
}