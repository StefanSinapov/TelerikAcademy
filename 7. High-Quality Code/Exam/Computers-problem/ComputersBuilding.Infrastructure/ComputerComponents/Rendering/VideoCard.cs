using System;
using ComputersBuilding.Infrastructure.ComputerComponents.Contracts;

namespace ComputersBuilding.Infrastructure.ComputerComponents.Rendering
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
