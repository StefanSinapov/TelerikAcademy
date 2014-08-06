using ComputersBuilding.ComputerComponents.Contracts;

namespace ComputersBuilding.Contracts
{
    public interface IComputer
    {
        ICentralProcessingUnit Cpu { get; }

        IRandomAccessMemory Ram { get; }

        IVideoCard Gpu { get; }

        IStorage Storage { get; }
    }
}
