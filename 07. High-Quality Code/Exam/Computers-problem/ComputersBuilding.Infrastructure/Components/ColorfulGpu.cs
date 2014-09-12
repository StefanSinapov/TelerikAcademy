namespace ComputersBuilding.Components
{
    using System;

    public class ColorfulGpu : VideoCard
    {
        public override void Draw(string inputData)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            this.RenderInformation(inputData);
        }
    }
}
