using ComputersBuilding.ComputerComponents.Contracts;

namespace ComputersBuilding.Contracts
{
    public interface ILaptop
    {
        IRechargable Battery { get; }

        ICentralProcessingUnit Cpu { get; }

        IRandomAccessMemory Ram { get; }
        
        IVideoCard Gpu { get; }
        
        IStorage Storage { get; }

        void Play(int guessNumber);

        void ChargeBattery(int powerPercentage);
    }
}