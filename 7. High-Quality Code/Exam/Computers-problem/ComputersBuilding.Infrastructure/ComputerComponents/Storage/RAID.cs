using System;
using System.Collections.Generic;
using System.Linq;
using ComputersBuilding.ComputerComponents.Contracts;

namespace ComputersBuilding.ComputerComponents.Storage
{
    public class Raid : IStorage
    {
        private readonly IList<HardDrive> hardDrives;

        public Raid()
            : this(new List<HardDrive>())
        {
        }

        public Raid(IList<HardDrive> hardDrives)
        {
            this.hardDrives = hardDrives;
        }

        public int Capacity
        {
            get
            {
                if (!this.hardDrives.Any())
                {
                    return 0;
                }

                return this.hardDrives.First().Capacity;
            }
        }

        public void SaveData(int address, string newData)
        {
            foreach (var hardDrive in this.hardDrives)
            {
                hardDrive.SaveData(address, newData);
            }
        }

        public string LoadData(int address)
        {
            if (!this.hardDrives.Any())
            {
                throw new OutOfMemoryException("No hard drive in the RAID array!");
            }

            return this.hardDrives.First().LoadData(address);
        }
    }
}
