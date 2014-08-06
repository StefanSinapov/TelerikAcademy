using System;

namespace ComputersBuilding.ComputerComponents.Rendering
{
    public class MonochromeGpu : VideoCard
    {
        public override void Draw(string inputData)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            this.RenderInformation(inputData);
        }
    }
}
