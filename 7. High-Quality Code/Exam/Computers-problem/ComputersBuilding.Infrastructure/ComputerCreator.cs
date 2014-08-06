namespace ComputersBuilding.Infrastructure
{
    using Contracts;
    using Factory;

    public class ComputerCreator
    {
        private readonly ComputerFactory computerFactory;

        public ComputerCreator(ComputerFactory factory)
        {
            this.computerFactory = factory;
        }

        public IDesktop AssembleDesktop()
        {
            return this.computerFactory.CreateDesktop();
        }

        public IServer AssembleServer()
        {
            return this.computerFactory.CreateServer();
        }

        public ILaptop AssembleLaptop()
        {
            return this.computerFactory.CreateLaptop();
        }
    }
}
