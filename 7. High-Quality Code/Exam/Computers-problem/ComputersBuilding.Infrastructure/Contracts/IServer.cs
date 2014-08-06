using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;

namespace ComputersBuilding.Infrastructure.Contracts
{
    public interface IServer
    {
        void Process(int data);
        ICentralProcessingUnit Cpu { get; }
        IRandomAccessMemory Ram { get; }
        IVideoCard Gpu { get; }
        IStorage Storage { get; }
    }
}