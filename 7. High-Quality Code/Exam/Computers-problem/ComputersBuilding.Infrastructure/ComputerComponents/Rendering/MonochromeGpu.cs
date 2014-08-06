using System;

namespace ComputersBuilding.Infrastructure.ComputerComponents.Rendering
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
