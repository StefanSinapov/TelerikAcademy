using ComputersBuilding.ComputerComponents.Contracts;

namespace ComputersBuilding.ComputerComponents.Memory
{
    public class RandomAccessMemory : IRandomAccessMemory
    {
        internal RandomAccessMemory(int amount)
        { 
            this.Amount = amount;
        }

        public int Value { get; set; }

        public int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            this.Value = newValue;
        }
        
        public int LoadValue()
        {
            return this.Value;
        }
    }
}