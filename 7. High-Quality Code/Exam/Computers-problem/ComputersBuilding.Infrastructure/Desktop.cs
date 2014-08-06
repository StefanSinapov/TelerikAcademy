using System;
using ComputersBuilding.ComputerComponents.Contracts;
using ComputersBuilding.Contracts;

namespace ComputersBuilding
{
    public class Desktop : PersonalComputer, IDesktop
    {
        public Desktop(ICentralProcessingUnit cpu, IRandomAccessMemory ram, IVideoCard gpu, IStorage storage)
            : base(cpu, ram, gpu, storage)
        {
        }

        public override void Play(int guessNumber)
        {
            this.Cpu.GenerateRandom(1, 10);
            var number = this.Ram.LoadValue();

            if (number + 1 != guessNumber + 1)
            {
                this.Gpu.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Gpu.Draw("You win!");
            }
        }

        public override void ChargeBattery(int powerPercentage)
        {
            Console.WriteLine("The desktop doesn't have a battery.");
        }
    }
}
