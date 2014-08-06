namespace ComputersBuilding.Infrastructure.Factory
{
    using System.Collections.Generic;
    using ComputerComponents.Contracts;
    using ComputerComponents.Memory;
    using ComputerComponents.Power;
    using ComputerComponents.Processing;
    using ComputerComponents.Rendering;
    using ComputerComponents.Storage;
    using Contracts;


    // Concrete Factory
    public class LenovoFactory : ComputerFactory
    {
        public LenovoFactory()
        {
        }

        public override IDesktop CreateDesktop()
        {
            IRandomAccessMemory ram = new RandomAccessMemory(4);
            IVideoCard gpu = new MonochromeGpu();
            ICentralProcessingUnit cpu = new CentralProcessingUnit(2, CpuArchitecture.Bit64, ram, gpu);
            IStorage storage = new HardDrive(2000);

            return new Desktop(cpu, ram, gpu, storage);
        }

        public override IServer CreateServer()
        {
            var raidDrives = new List<HardDrive>
            {
                new HardDrive(500),
                new HardDrive(500)
            };

            IRandomAccessMemory ram = new RandomAccessMemory(8);
            IVideoCard gpu = new MonochromeGpu();
            ICentralProcessingUnit cpu = new CentralProcessingUnit(2, CpuArchitecture.Bit128, ram, gpu);
            IStorage storage = new RAID(raidDrives);

            return new Server(cpu, ram, gpu, storage);
        }

        public override ILaptop CreateLaptop()
        {
            IRandomAccessMemory ram = new RandomAccessMemory(16);
            IVideoCard gpu = new ColorfulGpu();
            ICentralProcessingUnit cpu = new CentralProcessingUnit(2, CpuArchitecture.Bit64, ram, gpu);
            IStorage storage = new HardDrive(1000);
            IRechargable battery = new Battery();

            return new Laptop(cpu, ram, gpu, storage, battery);
        }
    }
}
