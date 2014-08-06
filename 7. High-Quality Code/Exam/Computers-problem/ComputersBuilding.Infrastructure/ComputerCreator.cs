using ComputersBuilding.Contracts;
using ComputersBuilding.Factory;

namespace ComputersBuilding
{
    public class ComputerCreator
    {
        private readonly ComputerFactory computerFactory;

        public ComputerCreator(ComputerFactory computerFactory)
        {
            this.computerFactory = computerFactory;
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
