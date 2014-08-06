namespace ComputersBuilding
{
    internal class Ram
    {
        private int Value { get; set; }

        internal Ram(int amount)
        {
            this.Amount = amount;
        }

        private int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            this.Value = newValue;
        }

        public int LoadValue()
        {
            return Value;
        }
    }
}