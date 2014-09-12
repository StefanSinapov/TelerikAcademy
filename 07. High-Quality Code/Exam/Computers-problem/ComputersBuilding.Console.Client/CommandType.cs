namespace ComputersBuilding
{
    public class CommandType
    {
        public CommandType(string name, int argument)
        {
            this.Name = name;
            this.Argument = argument;
        }

        public string Name { get; set; }

        public int Argument { get; set; }
    }
}
