using ComputersBuilding.ComputerComponents.Contracts;
using ComputersBuilding.ComputerComponents.Power;

namespace ComputerBuilding.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BatteryChargeTests
    {
        private IRechargable battery;

        [TestInitialize]
        public void CrateNewBattery()
        {
            this.battery = new Battery();
        }

        [TestMethod]
        public void InitialBatteryChargeShoudBe50()
        {
            Assert.AreEqual(50, this.battery.CurrentCharge);
        }

        [TestMethod]
        public void ChargeWith50ShoudReturn100Charged()
        {
            this.battery.Charge(50);

            Assert.AreEqual(100, this.battery.CurrentCharge);
        }

        [TestMethod]
        public void ChargeWithNegativeValueShoudDropTheChargePercentage()
        {
            var initialCharge = this.battery.CurrentCharge;
            this.battery.Charge(-5);
            Assert.IsTrue(this.battery.CurrentCharge < initialCharge);
        }

        [TestMethod]
        public void ChargeWithPOsitiveValueShoudIncreseTheChargePercentage()
        {
            var initialCharge = this.battery.CurrentCharge;
            this.battery.Charge(5);
            Assert.IsTrue(initialCharge < this.battery.CurrentCharge);
        }

        [TestMethod]
        public void ChargeWithHigherThanTheMaxChargeShoudSetChargeTo100()
        {
            var chargeValue = this.battery.CurrentCharge * 5;
            this.battery.Charge(chargeValue);

            Assert.AreEqual(100, this.battery.CurrentCharge);
        }

        [TestMethod]
        public void ChargeWithLowerThanTheMinChargeShoudSetChargeTo0()
        {
            var chargeValue = this.battery.CurrentCharge * -5;
            this.battery.Charge(chargeValue);

            Assert.AreEqual(0, this.battery.CurrentCharge);
        }

        [TestMethod]
        public void ChargingWithZeroShoudNotChangeTheInitialCharge()
        {
            var initialCharge = this.battery.CurrentCharge;
            this.battery.Charge(0);

            Assert.AreEqual(initialCharge, this.battery.CurrentCharge);
        }
    }
}
