using ComputersBuilding.ComputerComponents.Contracts;
using ComputersBuilding.Contracts;

namespace ComputersBuilding
{
    public class Server : Computer, IServer
    {
        public Server(ICentralProcessingUnit cpu, IRandomAccessMemory ram, IVideoCard gpu, IStorage storage)
            : base(cpu, ram, gpu, storage)
        {
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);
            this.Cpu.SquareNumber();
        }
    }
}
