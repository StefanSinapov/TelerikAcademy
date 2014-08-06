namespace ComputersBuilding.Infrastructure.ComputerComponents.Contracts
{
    public interface IRechargable
    {
        int CurrentCharge { get; }

        void Charge(int powerInput);
    }
}
