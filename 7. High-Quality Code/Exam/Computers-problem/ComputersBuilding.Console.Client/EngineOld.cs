namespace ComputersBuilding
{
    using System;
    using System.Collections.Generic;
    using ComputersBuilding.Enums;

    public class EngineOld
    {
        static Computer pc, laptop, server;

        private static EngineOld instance;

        private EngineOld()
        {

        }

        public static EngineOld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EngineOld();
                }

                return instance;
            }
        }

        private const int Eight = 8;

        public void Run()
        {
            var manufacturer = Console.ReadLine();

            if (manufacturer == "HP")
            {
                var ram = new Ram(Eight / 4);
                var videoCard = new HardDriver() { IsMonochrome = false };
                pc = new Computer(ComputerType.PC, new Cpu(Eight / 4, 32, ram, videoCard), ram, new[] { new HardDriver(500, false, 0) }, videoCard, null);

                var serverRam = new Ram(Eight * 4);
                var serverVideo = new HardDriver();
                server = new Computer(ComputerType.SERVER, new Cpu(Eight / 2, 32, serverRam, serverVideo), serverRam, new List<HardDriver> { new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(1000, false, 0), new HardDriver(1000, false, 0) }) },
                        serverVideo, null);
                {
                    var card = new HardDriver()
                    {
                        IsMonochrome
                            = false
                    };
                    var ram1 = new Ram(Eight / 2);
                    laptop = new Computer(ComputerType.LAPTOP, new Cpu(Eight / 4, 64, ram1, card), ram1, new[] {
                                new HardDriver(500,
                                    false, 0)
                            },
                        card,
                        new System.LaptopBattery());
                }
            }
            else if (manufacturer == "Dell")
            {
                var ram = new Ram(Eight); var videoCard = new HardDriver() { IsMonochrome = false };
                pc = new Computer(ComputerType.PC, new Cpu(Eight / 2, 64, ram, videoCard), ram, new[] { new HardDriver(1000, false, 0) }, videoCard, null);
                var ram1 = new Ram(Eight * Eight);
                var card = new HardDriver(); server = new Computer(ComputerType.SERVER,
                     new Cpu(Eight, 64, ram1, card),
                     ram1,
                     new List<HardDriver>{
                            new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(2000, false, 0), new HardDriver(2000, false, 0) })
                        }, card, null); var ram2 = new Ram(Eight); var videoCard1 = new HardDriver() { IsMonochrome = false };
                laptop = new Computer(ComputerType.LAPTOP,
                    new Cpu(Eight / 2, ((32)), ram2, videoCard1),
                    ram2,
                    new[] { new HardDriver(1000, false, 0) },
                    videoCard1,

                    new System.LaptopBattery());
            }
            else { throw new ArgumentException("Invalid manufacturer!"); }


            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine == null || inputLine.StartsWith("Exit"))
                {
                    break;
                }
                var inputSplited = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (inputSplited.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");

                }

                var commandName = inputSplited[0];
                var commandParameter = int.Parse(inputSplited[1]);



                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandParameter);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandParameter);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandParameter);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }

    }
}
