namespace ComputersBuilding.Contracts
{
    internal interface IMotherboard
    {
        int LoadRamValue();
        void SaveRamValue(int value);
        void DrawOnVideoCard(string data);
    }
}
