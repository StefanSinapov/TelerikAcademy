using ComputersBuilding.Contracts;

namespace ComputersBuilding.Factory
{
    public abstract class ComputerFactory
    {
        public abstract IDesktop CreateDesktop();

        public abstract IServer CreateServer();

        public abstract ILaptop CreateLaptop();
    }
}
