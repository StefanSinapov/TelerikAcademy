namespace ComputersBuilding.ComputerComponents.Contracts
{
    public interface IRechargable
    {
        int CurrentCharge { get; }

        void Charge(int powerInput);
    }
}
