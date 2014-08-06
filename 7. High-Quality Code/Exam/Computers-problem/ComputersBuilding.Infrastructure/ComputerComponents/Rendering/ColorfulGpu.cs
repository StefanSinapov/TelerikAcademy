using System;

namespace ComputersBuilding.ComputerComponents.Rendering
{
    public class ColorfulGpu : VideoCard
    {
        public override void Draw(string inputData)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.RenderInformation(inputData);
        }
    }
}
