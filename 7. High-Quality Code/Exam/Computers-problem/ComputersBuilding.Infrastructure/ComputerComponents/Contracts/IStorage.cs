namespace ComputersBuilding.ComputerComponents.Contracts
{
    public interface IStorage
    {
        void SaveData(int address, string newData);

        string LoadData(int address);
    }
}
