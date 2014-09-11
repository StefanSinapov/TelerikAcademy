using CalculatorAsyncInvoke.ServiceCalculator;
using System;

namespace CalculatorAsyncInvoke
{
    class InvokeCalculatorAsync
    {
        private static ServiceCalculatorClient calculatorClient = 
            new ServiceCalculatorClient();

        static void Main()
        {
            calculatorClient.BeginCalculate(
                3, 5, CalculationOperation.Add, CalculationFinished, null);
            Console.WriteLine("Service invoked asynchronously.");
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }

        static void CalculationFinished(IAsyncResult asyncResult)
        {
            int result = calculatorClient.EndCalculate(asyncResult);
            System.Console.WriteLine("The result returned by the WCF service is: " + result);
        }
    }
}
