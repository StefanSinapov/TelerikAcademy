using System;
using ComputersBuilding.Infrastructure;
using ComputersBuilding.Infrastructure.Contracts;
using ComputersBuilding.Infrastructure.Factory;

namespace ComputersBuilding
{
    public class Engine
    {
        private static Engine instance;

        private Engine()
        {
        }

        public static Engine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }

        public IDesktop Desktop
        {
            get;
            private set;
        }

        public IServer Server
        {
            get;
            private set;
        }

        public ILaptop Laptop
        {
            get;
            private set;
        }

        public void Run()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "HP":
                    ComputerFactory hp = new HewlettPackardFactory();
                    this.CreateComputers(hp);
                    break;

                case "Dell":
                    ComputerFactory dell = new DellFactory();
                    this.CreateComputers(dell);
                    break;

                case "Lenovo":
                    ComputerFactory lenovo = new LenovoFactory();
                    this.CreateComputers(lenovo);
                    break;

                default:
                    throw new ArgumentException("Invalid manufacturer!");
                    break;
            }

            this.OperationReciever();
        }

        private void OperationReciever()
        {
            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == null || userInput.StartsWith("Exit"))
                {
                    break;
                }

                var command = userInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (command.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                string operation = command[0];
                int operand = int.Parse(command[1]);

                switch (operation)
                {
                    case "Charge":
                        this.Laptop.ChargeBattery(operand);
                        break;

                    case "Process":
                        this.Server.Process(operand);
                        break;

                    case "Play":
                        this.Desktop.Play(operand);
                        break;

                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }

        private void CreateComputers(ComputerFactory factory)
        {
            ComputerCreator creator = new ComputerCreator(factory);

            this.Desktop = creator.AssembleDesktop();
            this.Server = creator.AssembleServer();
            this.Laptop = creator.AssembleLaptop();
        }
    }
}
