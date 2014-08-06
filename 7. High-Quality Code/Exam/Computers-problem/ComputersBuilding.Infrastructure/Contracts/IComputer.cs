using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;

namespace ComputersBuilding.Infrastructure.Contracts
{
    public interface IComputer
    {
        ICentralProcessingUnit Cpu { get; }

        IRandomAccessMemory Ram { get; }

        IVideoCard Gpu { get; }

        IStorage Storage { get; }
    }
}
