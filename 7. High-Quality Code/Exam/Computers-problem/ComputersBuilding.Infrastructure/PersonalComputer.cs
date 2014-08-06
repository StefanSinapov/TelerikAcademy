using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;
using ComputersBuilding.Infrastructure.ComputerComponents.Memory;
using ComputersBuilding.Infrastructure.ComputerComponents.Processing;

namespace ComputersBuilding.Infrastructure
{
    public abstract class PersonalComputer : Computer
    {
        public PersonalComputer(ICentralProcessingUnit cpu, IRandomAccessMemory ram, IVideoCard gpu, IStorage storage)
            : base(cpu, ram, gpu, storage)
        {
        }

        public abstract void Play(int guessNumber);

        public abstract void ChargeBattery(int powerPercentage);
    }
}
