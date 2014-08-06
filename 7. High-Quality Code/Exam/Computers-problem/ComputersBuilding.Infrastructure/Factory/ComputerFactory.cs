namespace ComputersBuilding.Infrastructure.Factory
{
    using ComputersBuilding.Infrastructure.Contracts;

    public abstract class ComputerFactory
    {
        public abstract IDesktop CreateDesktop();

        public abstract IServer CreateServer();

        public abstract ILaptop CreateLaptop();
    }
}
