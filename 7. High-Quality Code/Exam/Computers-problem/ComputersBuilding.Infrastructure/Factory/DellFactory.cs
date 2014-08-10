namespace ComputersBuilding.Factory
{
    using System.Collections.Generic;
    using Components;
    using Contracts;

    // Concrete Factory
    public class DellFactory : ComputerFactory
    {
        public DellFactory()
        {
        }

        public override IDesktop CreateDesktop()
        {
            IRandomAccessMemory ram = new RandomAccessMemory(8);
            IVideoCard gpu = new ColorfulGpu();
            ICentralProcessingUnit cpu = new CentralProcessingUnit(4, CpuArchitecture.Bit64, ram, gpu);
            IStorage storage = new HardDrive(1000);

            return new Desktop(cpu, ram, gpu, storage);
        }

        public override IServer CreateServer()
        {
            var raidDrives = new List<HardDrive>
            {
                new HardDrive(2000),
                new HardDrive(2000)
            };

            IRandomAccessMemory ram = new RandomAccessMemory(64);
            IVideoCard gpu = new MonochromeGpu();
            ICentralProcessingUnit cpu = new CentralProcessingUnit(8, CpuArchitecture.Bit64, ram, gpu);
            IStorage storage = new Raid(raidDrives);

            return new Server(cpu, ram, gpu, storage);
        }

        public override ILaptop CreateLaptop()
        {
            IRandomAccessMemory ram = new RandomAccessMemory(8);
            IVideoCard gpu = new ColorfulGpu();
            ICentralProcessingUnit cpu = new CentralProcessingUnit(4, CpuArchitecture.Bit32, ram, gpu);
            IStorage storage = new HardDrive(1000);
            IRechargable battery = new Battery();

            return new Laptop(cpu, ram, gpu, storage, battery);
        }
    }
}
