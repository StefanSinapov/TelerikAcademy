namespace ComputersBuilding
{
    public class ConsoleClientEntryPoint
    {
        public static void Main()
        {
            var engine = Engine.Instance;
            engine.Run();
        }
    }
}