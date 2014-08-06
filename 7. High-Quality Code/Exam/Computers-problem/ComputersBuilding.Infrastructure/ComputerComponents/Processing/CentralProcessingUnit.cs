using System;
using ComputersBuilding.ComputerComponents.Contracts;

namespace ComputersBuilding.ComputerComponents.Processing
{
    public class CentralProcessingUnit : ICentralProcessingUnit
    {
        public static readonly Random Random = new Random();

        public CentralProcessingUnit(byte numberOfCores, CpuArchitecture bits, IRandomAccessMemory ram, IVideoCard videoCard)
        {
            this.Cores = numberOfCores;
            this.Architecture = bits;
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        public byte Cores { get; set; }

        public CpuArchitecture Architecture { get; private set; }

        public IRandomAccessMemory Ram { get; private set; }

        public IVideoCard VideoCard { get; private set; }

        public void SquareNumber()
        {
            if (this.Architecture == CpuArchitecture.Bit32)
            {
                this.CalculateSquareNumber(0, 500);
            }

            if (this.Architecture == CpuArchitecture.Bit64)
            {
                this.CalculateSquareNumber(0, 1000);
            }

            if (this.Architecture == CpuArchitecture.Bit128)
            {
                this.CalculateSquareNumber(0, 2000);
            }
        }

        public void GenerateRandom(int a, int b)
        {
            //// This is the second bottleneck (fixed: with removing do-while loop) 
            int randomNumber = Random.Next(a, b + 1);
            this.Ram.SaveValue(randomNumber);
        }

        private void CalculateSquareNumber(int minBound, int maxBound)
        {
            var data = this.Ram.LoadValue();

            if (data < minBound)
            {
                this.VideoCard.Draw("Number too low.");
            }
            else if (data > maxBound)
            {
                this.VideoCard.Draw("Number too high.");
            }
            else
            {
                ////This is first bottleneck - fixed with simple math.
                var value = data * data;
                this.VideoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }
    }
}