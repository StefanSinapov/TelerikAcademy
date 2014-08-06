using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;

namespace ComputersBuilding.Infrastructure.Contracts
{
    public interface IDesktop
    {
        void Play(int guessNumber);
        void ChargeBattery(int powerPercentage);
        ICentralProcessingUnit Cpu { get; }
        IRandomAccessMemory Ram { get; }
        IVideoCard Gpu { get; }
        IStorage Storage { get; }
    }
}