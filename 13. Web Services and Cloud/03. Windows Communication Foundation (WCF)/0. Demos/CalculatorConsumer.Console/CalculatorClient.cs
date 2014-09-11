using CalculatorConsumer.Console.ServiceCalculator;

namespace CalculatorConsumer.Console
{
    class CalculatorClient
    {
        static void Main()
        {
            ServiceCalculatorClient calculatorClient = new ServiceCalculatorClient();
            int result = calculatorClient.Calculate(3, 5, CalculationOperation.Add);
            System.Console.WriteLine("The result returned by the WCF service is: " + result);
        }
    }
}
