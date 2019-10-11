using System;

namespace StructsAndEnums.Structs
{
    public struct Rectangle : ISize, ICoordinates
    {
        private double _width;
        private double _height;

        public double Width
        {
            get { return _width; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                       $"{nameof(value)} must be positive.");
                _width = value;
            }
        }
        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(
                       $"{nameof(value)} must be positive.");
                _height = value;
            }
        }
        public double X { get; set; }
        public double Y { get; set; }

        public double Perimeter()
        {
            return 2 * (Width + Height);
        }
    }
}
