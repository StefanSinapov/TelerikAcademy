namespace ComputersBuilding.Contracts
{
    public interface IDesktop
    {
        void Play(int guessNumber);

        void ChargeBattery(int powerPercentage);
    }
}