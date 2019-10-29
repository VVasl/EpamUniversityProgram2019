//-----------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace StyleCop
{
    using System;

    /// <summary>
    /// Stores a set of bottom-left point, width and height of Rectangle.
    /// Attempts to move rectangle along axis, resize rectangle, 
    /// compute the smallest rectangle containing two given rectangles
    /// and the intersecting rectangle formed by the given two rectangles.
    /// </summary>
    public class Rectangle 
    {
        private int widthOfRectangle;
        private int heightOfRectangle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// Constructor sets lengths of sides and coordinates of left-bottom point of rectangle.
        /// </summary>
        /// <param name="bottomLeftCoordinate">Left-bottom point of rectangle.</param>
        /// <param name="widthOfRectangle">Length of top and bottom sides of rectangle.</param>
        /// <param name="heightOfRectangle">Length of left and right sides of rectangle.</param>
        public Rectangle(Point bottomLeftCoordinate, int widthOfRectangle, int heightOfRectangle)
        {
            this.BottomLeftCoordinate = bottomLeftCoordinate;
            this.WidthOfRectangle = widthOfRectangle;
            this.HeightOfRectangle = heightOfRectangle;
        }

        /// <summary>
        /// Gets or sets the bottom-left coordinate of this Rectangle class.
        /// </summary>
        private Point BottomLeftCoordinate { get; set; }

        /// <summary>
        /// Gets or sets the width of this Rectangle class.
        /// </summary>
       // private int WidthOfRectangle { get; set; }
        public int WidthOfRectangle
        {
            get { return this.widthOfRectangle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be positive.");
                }

                this.widthOfRectangle = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of this Rectangle class.
        /// </summary>
        private int HeightOfRectangle
        {
            get { return this.heightOfRectangle; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be positive.");
                }

                this.HeightOfRectangle = value;
            }
        }

        /// <summary>
        /// Method computes the smallest rectangle that contains two given rectangles  
        /// </summary>
        /// <param name="first">First rectangle.</param>
        /// <param name="second">Second rectangle.</param>
        /// <returns>New rectangle.</returns>
        public static Rectangle FindTheSmallestRectangle(Rectangle first, Rectangle second)
        {
            int leftBottomX = Math.Min(first.BottomLeftCoordinate.X, second.BottomLeftCoordinate.X);
            int leftBottomY = Math.Min(first.BottomLeftCoordinate.Y, second.BottomLeftCoordinate.Y);
            int rightTopX = Math.Max(first.BottomLeftCoordinate.X + first.WidthOfRectangle, second.BottomLeftCoordinate.X + second.WidthOfRectangle);
            int rightTopY = Math.Max(first.BottomLeftCoordinate.Y + first.HeightOfRectangle, second.BottomLeftCoordinate.Y + second.HeightOfRectangle);

            return new Rectangle(new Point(leftBottomX, leftBottomY), rightTopX - leftBottomX, rightTopY - leftBottomY);
        }

        /// <summary>
        /// Method returns the intersecting rectangle formed by the given two rectangles.
        /// </summary>
        /// <param name="first">First rectangle.</param>
        /// <param name="second">Second rectangle.</param>
        /// <returns>New rectangle.</returns>
        public static Rectangle FindIntersectionRectangle(Rectangle first, Rectangle second)
        {
            int leftBottomX = Math.Max(first.BottomLeftCoordinate.X, second.BottomLeftCoordinate.X);
            int leftBottomY = Math.Max(first.BottomLeftCoordinate.Y, second.BottomLeftCoordinate.Y);
            int rightTopX = Math.Min(first.BottomLeftCoordinate.X + first.WidthOfRectangle, second.BottomLeftCoordinate.X + second.WidthOfRectangle);
            int rightTopY = Math.Min(first.BottomLeftCoordinate.Y + first.HeightOfRectangle, second.BottomLeftCoordinate.Y + second.HeightOfRectangle);
            if (rightTopX >= leftBottomX && rightTopY >= leftBottomY)
            {
                return new Rectangle(new Point(leftBottomX, leftBottomY), rightTopX - leftBottomX, rightTopY - leftBottomY);
            }

            return null;
        }

        /// <summary>
        /// Method moves rectangle in appropriate direction.
        /// </summary>
        /// <param name="movementAlongX">Value that will change X coordinate of left-bottom point.</param>
        /// <param name="movementAlongY">Value that will change Y coordinate of left-bottom point.</param>
        public void MoveAlongAxis(int movementAlongX, int movementAlongY)
        {
            this.BottomLeftCoordinate.X += movementAlongX;
            this.BottomLeftCoordinate.Y += movementAlongY;
        }

        /// <summary>
        /// Method changes size of rectangle.
        /// </summary>
        /// <param name="changeWidth">New value of width in rectangle.</param>
        /// <param name="changeHeight">New value of height in rectangle.</param>
        public void Resize(int changeWidth, int changeHeight)
        {
            this.HeightOfRectangle += changeWidth;
            this.WidthOfRectangle += changeHeight;
        }

        /// <summary>
        /// The overriding method to provide information about Rectangle type .
        /// </summary>
        /// <returns>String representation of the object.</returns>
        public override string ToString()
        {
            return $"The bottom-left coordinate of a rectangle:({BottomLeftCoordinate.X}, {BottomLeftCoordinate.Y}) Width Of Rectangle:{WidthOfRectangle} Height Of Rectangle:{HeightOfRectangle}";
        }
    }
}
