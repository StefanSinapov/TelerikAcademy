namespace ComputersBuilding
{
    using Contracts;

    public abstract class PersonalComputer : Computer
    {
        protected PersonalComputer(ICentralProcessingUnit cpu, IRandomAccessMemory ram, IVideoCard gpu, IStorage storage)
            : base(cpu, ram, gpu, storage)
        {
        }

        public abstract void Play(int guessNumber);

        public abstract void ChargeBattery(int powerPercentage);
    }
}
