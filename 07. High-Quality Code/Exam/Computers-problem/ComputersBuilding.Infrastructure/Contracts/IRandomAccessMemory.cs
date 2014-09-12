namespace ComputersBuilding.Contracts
{
    public interface IRandomAccessMemory
    {
        void SaveValue(int newValue);

        int LoadValue();
    }
}