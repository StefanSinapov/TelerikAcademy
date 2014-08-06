using System;
using System.Collections.Generic;
using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;

namespace ComputersBuilding.Infrastructure.ComputerComponents.Storage
{
    public class HardDrive : IStorage
    {
        private int capacity;
        private IDictionary<int, string> data;

        public HardDrive(int capacity)
        {
            this.Capacity = capacity;
            this.data = new Dictionary<int, string>(this.Capacity);
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("You cannot set capacity to a negative value");
                }

                this.capacity = value;
            }
        }

        public void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }

        public string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
