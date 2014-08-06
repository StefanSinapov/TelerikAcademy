namespace ComputersBuilding.Infrastructure
{
    using ComputerComponents.Contracts;
    using Contracts;

    public abstract class Computer : IComputer
    {
        protected Computer(ICentralProcessingUnit cpu, IRandomAccessMemory ram, IVideoCard gpu, IStorage storage)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.Gpu = gpu;
            this.Storage = storage;
        }

        public ICentralProcessingUnit Cpu
        {
            get;
            private set;
        }

        public IRandomAccessMemory Ram
        {
            get;
            private set;
        }

        public IVideoCard Gpu
        {
            get;
            private set;
        }

        public IStorage Storage
        {
            get;
            private set;
        }
    }
}
