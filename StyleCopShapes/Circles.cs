namespace StyleCopShapes
{
    using System;
    using Common;

     public class Circles : IShapes<Circle>
     {
        private readonly IWriter writer;

        public Circles(Circle shapeOne, Circle shapeTwo)
        {
            this.ShapeOne = shapeOne;
            this.ShapeTwo = shapeTwo;
            this.writer = new ConsoleInputOutput();
        }

        public Circle ShapeOne { get; set; }

        public Circle ShapeTwo { get; set; }

        public bool DoShapesOverlap()
        {
            double distanceBetweenTheCirclesCenters = this.FindDistanceBetweenTheCirclesCenters();

            if (distanceBetweenTheCirclesCenters == (this.ShapeOne.Radius + this.ShapeTwo.Radius))
            {
                this.writer.Write("The circles touch at a single point.");
            } 

            if (distanceBetweenTheCirclesCenters > (this.ShapeOne.Radius + this.ShapeTwo.Radius))
            {
                this.writer.Write("The circles are too far apart to intersect.");
                return false;
            }
            else
            {
                this.writer.Write("The circles touch at two points.");
                return true;
            }
        }

        public Circle FindIntersectionOfShapes()
        {
            double distanceBetweenTheCirclesCenters = this.FindDistanceBetweenTheCirclesCenters();

            return new Circle(new Point((this.ShapeOne.Center.X + this.ShapeTwo.Center.X + (this.ShapeOne.Radius - this.ShapeTwo.Radius) * (this.ShapeTwo.Center.X - this.ShapeOne.Center.X) / distanceBetweenTheCirclesCenters) / 2,
                      (this.ShapeOne.Center.Y + this.ShapeTwo.Center.Y + (this.ShapeOne.Radius - this.ShapeTwo.Radius) * (this.ShapeTwo.Center.Y - this.ShapeOne.Center.Y) / distanceBetweenTheCirclesCenters) / 2),
                      ((this.ShapeOne.Radius + this.ShapeTwo.Radius) - distanceBetweenTheCirclesCenters) / 2);
        }

        public double FindDistanceBetweenTheCirclesCenters()
        {
           return Math.Sqrt((this.ShapeOne.Center.X - this.ShapeTwo.Center.X) * (this.ShapeOne.Center.X - this.ShapeTwo.Center.X) +
                                                (this.ShapeOne.Center.Y - this.ShapeTwo.Center.Y) * (this.ShapeOne.Center.Y - this.ShapeTwo.Center.Y));
        }
    }
}
