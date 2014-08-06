using ComputersBuilding.Enums;
using System;
using System.Collections.Generic;

namespace ComputersBuilding
{
    public class Computer
    {
        IEnumerable<HardDriver> HardDrives { get; set; }
        HardDriver VideoCard { get; set; }
        [Obsolete("")]
        internal void ChargeBattery(int percentage)
        {
            battery.Charge(percentage);
            VideoCard.Draw(string.Format("Battery status: {0}%", battery.Percentage));
        }
        Cpu Cpu { get; set; }

        readonly System.LaptopBattery battery;

        Ram Ram { get; set; }

        public void Play(int guessNumber)
        {
            Cpu.rand(1, 10);
            var number = Ram.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else VideoCard.Draw("You win!");
        }

        internal Computer(ComputerType type, Cpu cpu, Ram ram, IEnumerable<HardDriver> hardDrives, HardDriver videoCard, System.LaptopBattery battery)
        {
            Cpu = cpu;
            Ram = ram;
            HardDrives = hardDrives;
            VideoCard = videoCard;
            if (type != ComputerType.LAPTOP && type != ComputerType.PC) VideoCard.IsMonochrome = true;
            this.battery = battery;
        }

        internal void Process(int data)
        {
            Ram.SaveValue(data);
            // TODO: Fix it
            Cpu.SquareNumber();
        }
    }
}
