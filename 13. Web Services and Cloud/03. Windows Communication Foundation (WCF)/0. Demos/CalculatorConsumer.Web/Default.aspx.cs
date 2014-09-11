using System;
using CalculatorConsumerWebApp.ServiceCalculator;

public partial class Default : System.Web.UI.Page
{
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        ServiceCalculatorClient client = new ServiceCalculatorClient();
        int firstNumber = int.Parse(TextBoxFirstNumber.Text);
        int secondNumber = int.Parse(TextBoxSecondNumber.Text);
        LabelResult.Text = "Result: " + client.Calculate(
            firstNumber, secondNumber, CalculationOperation.Add);
    }

    protected void ButtonSubstract_Click(object sender, EventArgs e)
    {
        ServiceCalculatorClient client = new ServiceCalculatorClient();
        int firstNumber = int.Parse(TextBoxFirstNumber.Text);
        int secondNumber = int.Parse(TextBoxSecondNumber.Text);
        LabelResult.Text = "Result: " + client.Calculate(
            firstNumber, secondNumber, CalculationOperation.Substract);
    }

    protected void ButtonMultiply_Click(object sender, EventArgs e)
    {
        ServiceCalculatorClient client = new ServiceCalculatorClient();
        int firstNumber = int.Parse(TextBoxFirstNumber.Text);
        int secondNumber = int.Parse(TextBoxSecondNumber.Text);
        LabelResult.Text = "Result: " + client.Calculate(
            firstNumber, secondNumber, CalculationOperation.Multiply);
    }

    protected void ButtonDivide_Click(object sender, EventArgs e)
    {
        ServiceCalculatorClient client = new ServiceCalculatorClient();
        int firstNumber = int.Parse(TextBoxFirstNumber.Text);
        int secondNumber = int.Parse(TextBoxSecondNumber.Text);
        LabelResult.Text = "Result: " + client.Calculate(
            firstNumber, secondNumber, CalculationOperation.Divide);
    }
}
