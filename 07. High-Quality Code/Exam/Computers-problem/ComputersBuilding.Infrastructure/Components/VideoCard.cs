namespace ComputersBuilding.Components
{
    using System;
    using Contracts;

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
