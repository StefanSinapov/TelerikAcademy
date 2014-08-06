using System;
using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;
using ComputersBuilding.Infrastructure.ComputerComponents.Memory;

namespace ComputersBuilding.Infrastructure.ComputerComponents.Processing
{
    public class CentralProcessingUnit : ICentralProcessingUnit
    {
        public static readonly Random Random = new Random();

        private readonly byte cores;
        private readonly CpuArchitecture architecture;
        private readonly IRandomAccessMemory ram;
        private readonly IVideoCard videoCard;

        internal CentralProcessingUnit(byte numberOfCores, CpuArchitecture bits, IRandomAccessMemory ram, IVideoCard videoCard)
        {
            this.cores = numberOfCores;
            this.architecture = bits;
            this.ram = ram;
            this.videoCard = videoCard;
        }

        public byte Cores
        {
            get
            {
                return this.cores;
            }
        }

        public CpuArchitecture Architecture
        {
            get
            {
                return this.architecture;
            }
        }

        public IRandomAccessMemory Ram
        {
            get
            {
                return this.ram;
            }
        }

        public IVideoCard VideoCard
        {
            get
            {
                return this.videoCard;
            }
        }

        public void SquareNumber()
        {
            if (this.architecture == CpuArchitecture.Bit32)
            {
                this.CalculateSquareNumber(0, 500);
            }

            if (this.architecture == CpuArchitecture.Bit64)
            {
                this.CalculateSquareNumber(0, 1000);
            }

            if (this.architecture == CpuArchitecture.Bit128)
            {
                this.CalculateSquareNumber(0, 2000);
            }
        }

        public void GenerateRandom(int a, int b)
        {
            int randomNumber;

            do
            {
                randomNumber = Random.Next(0, 1000);
            }
            while (!(randomNumber >= a && randomNumber <= b));

            this.ram.SaveValue(randomNumber);
        }

        private void CalculateSquareNumber(int minBound, int maxBound)
        {
            var data = this.ram.LoadValue();

            if (data < minBound)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > maxBound)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                int value = 0;

                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }
    }
}
