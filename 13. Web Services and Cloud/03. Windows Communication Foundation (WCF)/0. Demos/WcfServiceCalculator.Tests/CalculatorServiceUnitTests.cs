using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceCalculator.Tests.ServiceCalculator;

namespace WcfServiceCalculator.Tests
{
    [TestClass]
    public class CalculatorServiceUnitTests
    {
        private ServiceCalculatorClient calculatorClient;

        [TestInitialize]
        public void TestInitialize()
        {
            this.calculatorClient = new ServiceCalculatorClient();
        }

        [TestMethod]
        public void AddTest()
        {
            int a = 5;
            int b = 3;
            CalculationOperation operation = CalculationOperation.Add;
            int expectedResult = 8;
            int actualResult = calculatorClient.Calculate(a, b, operation);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SubstractTest()
        {
            int a = 5;
            int b = 3;
            CalculationOperation operation = CalculationOperation.Substract;
            int expectedResult = 2;
            int actualResult = calculatorClient.Calculate(a, b, operation);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            int a = 5;
            int b = 3;
            CalculationOperation operation = CalculationOperation.Multiply;
            int expectedResult = 15;
            int actualResult = calculatorClient.Calculate(a, b, operation);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DivideTest()
        {
            int a = 10;
            int b = 2;
            CalculationOperation operation = CalculationOperation.Divide;
            int expectedResult = 5;
            int actualResult = calculatorClient.Calculate(a, b, operation);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
