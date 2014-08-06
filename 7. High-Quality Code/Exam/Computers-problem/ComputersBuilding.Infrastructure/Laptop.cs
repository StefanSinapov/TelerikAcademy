using System;
using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;
using ComputersBuilding.Infrastructure.Contracts;

namespace ComputersBuilding.Infrastructure
{
    public class Laptop : PersonalComputer, ILaptop
    {
        public Laptop(ICentralProcessingUnit cpu, IRandomAccessMemory ram, IVideoCard gpu, IStorage storage, IRechargable battery)
            : base(cpu, ram, gpu, storage)
        {
            this.Battery = battery;
        }

        public IRechargable Battery
        {
            get;
            private set;
        }

        public override void Play(int guessNumber)
        {
            Console.WriteLine("You cannot play games on your laptop.");
        }

        public override void ChargeBattery(int powerPercentage)
        {
            this.Battery.Charge(powerPercentage);

            this.Gpu.Draw(string.Format("Battery status: {0}", this.Battery.CurrentCharge));
        }
    }
}
