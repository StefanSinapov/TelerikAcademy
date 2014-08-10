namespace ComputersBuilding.Factory
{
    using Contracts;

    public abstract class ComputerFactory
    {
        public abstract IDesktop CreateDesktop();

        public abstract IServer CreateServer();

        public abstract ILaptop CreateLaptop();
    }
}
