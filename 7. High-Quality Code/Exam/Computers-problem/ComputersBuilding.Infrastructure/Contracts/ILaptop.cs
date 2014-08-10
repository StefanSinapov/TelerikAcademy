namespace ComputersBuilding.Contracts
{
    public interface ILaptop
    {
        void Play(int guessNumber);

        void ChargeBattery(int powerPercentage);
    }
}