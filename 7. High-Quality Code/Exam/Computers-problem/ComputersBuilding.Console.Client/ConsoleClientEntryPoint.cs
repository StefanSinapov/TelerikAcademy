namespace ComputersBuilding
{
    class ConsoleClientEntryPoint
    {
        public static void Main()
        {
            var engine = EngineOld.Instance;
            engine.Run();
        }
    }
}