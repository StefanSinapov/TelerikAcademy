using System.Collections.Generic;
using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;
using ComputersBuilding.Infrastructure.ComputerComponents.Memory;
using ComputersBuilding.Infrastructure.ComputerComponents.Power;
using ComputersBuilding.Infrastructure.ComputerComponents.Processing;
using ComputersBuilding.Infrastructure.ComputerComponents.Rendering;
using ComputersBuilding.Infrastructure.ComputerComponents.Storage;
using ComputersBuilding.Infrastructure.Contracts;

namespace ComputersBuilding.Infrastructure.Factory
{
    // Concrete Factory
    public class HewlettPackardFactory : ComputerFactory
    {
        public HewlettPackardFactory()
        {
        }

        public override IDesktop CreateDesktop()
        {
            IRandomAccessMemory ram = new RandomAccessMemory(2);
            IVideoCard gpu = new ColorfulGpu();
            ICentralProcessingUnit cpu = new CentralProcessingUnit(2, CpuArchitecture.Bit32, ram, gpu);
            IStorage storage = new HardDrive(500);

            return new Desktop(cpu, ram, gpu, storage);
        }

        public override IServer CreateServer()
        {
            var raidDrives = new List<HardDrive>
            {
                new HardDrive(1000),
                new HardDrive(1000)
            };

            IRandomAccessMemory ram = new RandomAccessMemory(32);
            IVideoCard gpu = new MonochromeGpu();
            ICentralProcessingUnit cpu = new CentralProcessingUnit(4, CpuArchitecture.Bit32, ram, gpu);
            IStorage storage = new RAID(raidDrives);

            return new Server(cpu, ram, gpu, storage);
        }

        public override ILaptop CreateLaptop()
        {
            IRandomAccessMemory ram = new RandomAccessMemory(4);
            IVideoCard gpu = new ColorfulGpu();
            ICentralProcessingUnit cpu = new CentralProcessingUnit(2, CpuArchitecture.Bit64, ram, gpu);
            IStorage storage = new HardDrive(500);
            IRechargable battery = new Battery();

            return new Laptop(cpu, ram, gpu, storage, battery);
        }
    }
}
