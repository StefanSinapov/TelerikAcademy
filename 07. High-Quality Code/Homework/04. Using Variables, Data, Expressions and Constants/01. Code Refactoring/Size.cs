namespace SizeCodeRefactoring
{
    using System;
    using System.Linq;

    public class Size
    {
        private double width;
        private double height;

        public Size(double initialWidth, double initialHeight)
        {
            this.Width = initialWidth;
            this.Height = initialHeight;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be negative");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be negative");
                }

                this.height = value;
            }
        }

        public static Size GetRotatedSize(Size initialSize, double angleSize)
        {
            if (angleSize < 0 || angleSize > 360)
            {
                throw new ArgumentOutOfRangeException("Angle size must be in range [0-360] degrees");
            }

            double newWidth = (Math.Abs(Math.Cos(angleSize)) * initialSize.Width) + (Math.Abs(Math.Sin(angleSize)) * initialSize.Height);
            double newHeight = (Math.Abs(Math.Sin(angleSize)) * initialSize.Width) + (Math.Abs(Math.Cos(angleSize)) * initialSize.Height);
            Size rotatedSize = new Size(newWidth, newHeight);
            return rotatedSize;
        }
    }
}
