namespace ComputerBuilding.Tests
{
    using ComputersBuilding.Components;
    using ComputersBuilding.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CpuRandomTests
    {
        private ICentralProcessingUnit cpu;
        private int mockedRamValue;

        [TestInitialize]
        public void CreateNewCpu()
        {
            var mockedRam = new Mock<IRandomAccessMemory>();
            mockedRam.Setup(r => r.SaveValue(It.IsAny<int>())).Callback((int value) => this.mockedRamValue = value);

            var mockedVideoCard = new Mock<IVideoCard>();

            this.cpu = new CentralProcessingUnit(4, CpuArchitecture.Bit32, mockedRam.Object, mockedVideoCard.Object);
        }

        [TestMethod]
        public void GenerateRandomFromCpuShoudSaveNumberToRam()
        {
            this.cpu.GenerateRandom(1, 10);
            Assert.IsNotNull(this.mockedRamValue);
        }

        [TestMethod]
        public void GeneratedRandomNumberShoudBeInGivenRange()
        {
            const int MinValue = 5;
            const int MaxValue = 50;
            this.cpu.GenerateRandom(MinValue, MaxValue);
            Assert.IsTrue(MinValue <= this.mockedRamValue);
            Assert.IsTrue(this.mockedRamValue <= MaxValue);
        }

        [TestMethod]
        public void GeneratedRandomNumberBetweenTwoАdjacentNumbersShoudReturnOneOrTheOther()
        {
            this.cpu.GenerateRandom(2, 3);
            bool firstNumber = this.mockedRamValue == 2 && this.mockedRamValue != 3;
            bool secondNumber = this.mockedRamValue != 2 && this.mockedRamValue == 3;

            Assert.IsTrue(firstNumber || secondNumber);
        }

        [TestMethod]
        public void GeneratedRandomNumberBetweenTwoSameNumbersShoudReturnSameNumber()
        {
            this.cpu.GenerateRandom(2, 2);
            Assert.AreEqual(2, this.mockedRamValue);
        }
    }
}
