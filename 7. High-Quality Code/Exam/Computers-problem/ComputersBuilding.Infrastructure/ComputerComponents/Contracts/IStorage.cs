namespace ComputersBuilding.Infrastructure.ComputerComponents.Contracts
{
    public interface IStorage
    {
        int Capacity { get; }

        void SaveData(int address, string newData);

        string LoadData(int address);
    }
}
