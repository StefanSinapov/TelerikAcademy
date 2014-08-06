using System;
using ComputersBuilding.ComputerComponents.Contracts;

namespace ComputersBuilding.ComputerComponents.Rendering
{
    public abstract class VideoCard : IVideoCard
    {
        public abstract void Draw(string inputData);

        protected void RenderInformation(string inputData)
        {
            Console.WriteLine(inputData);
            Console.ResetColor();
        }
    }
}
