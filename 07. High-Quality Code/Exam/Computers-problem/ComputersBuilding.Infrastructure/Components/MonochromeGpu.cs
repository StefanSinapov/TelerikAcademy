namespace ComputersBuilding.Components
{
    using System;

    public class MonochromeGpu : VideoCard
    {
        public override void Draw(string inputData)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            this.RenderInformation(inputData);
        }
    }
}
