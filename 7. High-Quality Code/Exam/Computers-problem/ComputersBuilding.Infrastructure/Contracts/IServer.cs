using ComputersBuilding.ComputerComponents.Contracts;

namespace ComputersBuilding.Contracts
{
    public interface IServer
    {
        ICentralProcessingUnit Cpu { get; }
        
        IRandomAccessMemory Ram { get; }
        
        IVideoCard Gpu { get; }
        
        IStorage Storage { get; }
        
        void Process(int data);
    }
}