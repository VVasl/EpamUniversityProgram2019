namespace StyleCopShapes
{
    using System;

    public class Rectangles : IShapes<Rectangle>
    {
        public Rectangles(Rectangle shapeOne, Rectangle shapeTwo)
        {
            this.ShapeOne = shapeOne;
            this.ShapeTwo = shapeTwo;
        }

        public Rectangle ShapeOne { get; set; }

        public Rectangle ShapeTwo { get; set; }

        public bool DoShapesOverlap()
        {
            bool xOverlap = this.IsValueInRange(this.ShapeOne.BottomLeftCoordinate.X, this.ShapeTwo.BottomLeftCoordinate.X, this.ShapeTwo.BottomLeftCoordinate.X + this.ShapeTwo.WidthOfRectangle) ||
                            this.IsValueInRange(this.ShapeTwo.BottomLeftCoordinate.X, this.ShapeOne.BottomLeftCoordinate.X, this.ShapeOne.BottomLeftCoordinate.X + this.ShapeOne.WidthOfRectangle);

            bool yOverlap = this.IsValueInRange(this.ShapeOne.BottomLeftCoordinate.Y, this.ShapeTwo.BottomLeftCoordinate.Y, this.ShapeTwo.BottomLeftCoordinate.Y + this.ShapeTwo.HeightOfRectangle) ||
                            this.IsValueInRange(this.ShapeTwo.BottomLeftCoordinate.Y, this.ShapeOne.BottomLeftCoordinate.Y, this.ShapeOne.BottomLeftCoordinate.Y + this.ShapeOne.HeightOfRectangle);
            
            return xOverlap && yOverlap;
        }

        /// <summary>
        /// Method returns the intersecting rectangle formed by the given two rectangles.
        /// </summary>
        /// <returns>New rectangle.</returns>
        public Rectangle FindIntersectionOfShapes()
        {
            double leftBottomX = Math.Max(this.ShapeOne.BottomLeftCoordinate.X, this.ShapeTwo.BottomLeftCoordinate.X);
            double leftBottomY = Math.Max(this.ShapeOne.BottomLeftCoordinate.Y, this.ShapeTwo.BottomLeftCoordinate.Y);
            double rightTopX = Math.Min(this.ShapeOne.BottomLeftCoordinate.X + this.ShapeOne.WidthOfRectangle, this.ShapeTwo.BottomLeftCoordinate.X + this.ShapeTwo.WidthOfRectangle);
            double rightTopY = Math.Min(this.ShapeOne.BottomLeftCoordinate.Y + this.ShapeOne.HeightOfRectangle, this.ShapeTwo.BottomLeftCoordinate.Y + this.ShapeTwo.HeightOfRectangle);
            if (rightTopX >= leftBottomX && rightTopY >= leftBottomY)
            {
                return new Rectangle(new Point(leftBottomX, leftBottomY), rightTopX - leftBottomX, rightTopY - leftBottomY);
            }

            return null;
        }

        /// <summary>
        /// Method computes the smallest rectangle that contains two given rectangles  
        /// </summary>
        /// <returns>New rectangle.</returns>
        public Rectangle FindTheSmallestRectangle()
        {
            double leftBottomX = Math.Min(this.ShapeOne.BottomLeftCoordinate.X, this.ShapeTwo.BottomLeftCoordinate.X);
            double leftBottomY = Math.Min(this.ShapeOne.BottomLeftCoordinate.Y, this.ShapeTwo.BottomLeftCoordinate.Y);
            double rightTopX = Math.Max(this.ShapeOne.BottomLeftCoordinate.X + this.ShapeOne.WidthOfRectangle, this.ShapeTwo.BottomLeftCoordinate.X + this.ShapeTwo.WidthOfRectangle);
            double rightTopY = Math.Max(this.ShapeOne.BottomLeftCoordinate.Y + this.ShapeOne.HeightOfRectangle, this.ShapeTwo.BottomLeftCoordinate.Y + this.ShapeTwo.HeightOfRectangle);

            return new Rectangle(new Point(leftBottomX, leftBottomY), rightTopX - leftBottomX, rightTopY - leftBottomY);
        }

        private bool IsValueInRange(double value, double min, double max)
        {
            return (value >= min) && (value <= max);
        }
    }
}
