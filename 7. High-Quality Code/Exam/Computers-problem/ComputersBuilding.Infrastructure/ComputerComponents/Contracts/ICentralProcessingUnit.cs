using ComputersBuilding.Infrastructure.ComputerComponents.Processing;

namespace ComputersBuilding.Infrastructure.ComputerComponents.Contracts
{
    public interface ICentralProcessingUnit
    {
        byte Cores { get; }
        CpuArchitecture Architecture { get; }
        IRandomAccessMemory Ram { get; }
        IVideoCard VideoCard { get; }
        void SquareNumber();
        void GenerateRandom(int a, int b);
    }
}