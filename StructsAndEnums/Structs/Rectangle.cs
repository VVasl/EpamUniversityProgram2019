

namespace StructsAndEnums.Structs
{
    using System;
    public struct Rectangle : ISize, ICoordinates
    {
        private double width;
        private double height;

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be positive.");
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
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be positive.");
                }
                    
                this.height = value;
            }
        }
        public double X { get; set; }
        public double Y { get; set; }

        public double Perimeter()
        {
            return 2 * (this.Width + this.Height);
        }
    }
}
