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
            get { return this.width; }
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
            get { return this.height; }
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
            //TODO: finish here
            double newWidth=0;
            double newHeight=0;
            return new Size(newWidth, newHeight);
        }
    }
}
