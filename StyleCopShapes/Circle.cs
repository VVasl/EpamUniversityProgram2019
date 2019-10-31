namespace StyleCopShapes
{
    using System;

    public class Circle
    {
        private double radius;

        public Circle(Point center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        public Point Center { get; set; }

        public double Radius
        {
            get 
            { 
                return this.radius; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be positive.");
                }

                this.radius = value;
            }
        }

        public Circle MoveAlongAxis(int movementAlongX, int movementAlongY)
        {
            return new Circle(new Point(this.Center.X + movementAlongX, this.Center.Y + movementAlongY), this.Radius);
        }

        public Circle Resize(double changedRadius)
        {
            return new Circle(new Point(this.Center.X, this.Center.Y), this.Radius + changedRadius);
        }

        /// <summary>
        /// The overriding method to provide information about Circle type .
        /// </summary>
        /// <returns>String representation of the object.</returns>
        public override string ToString()
        {
            return $"The center coordinate of a rectangle:({this.Center.X}, {this.Center.Y}) Radius Of Circle:{this.Radius}";
        }
    }
}
