namespace WarMachines.Engine
{
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            // TODO: Implement this method
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            // TODO: Implement this method
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            // TODO: Implement this method
        }
    }
}
