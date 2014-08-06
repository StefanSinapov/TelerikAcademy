namespace ComputersBuilding.Infrastructure.ComputerComponents.Contracts
{
    public interface IRandomAccessMemory
    {
        void SaveValue(int newValue);
        int LoadValue();
    }
}