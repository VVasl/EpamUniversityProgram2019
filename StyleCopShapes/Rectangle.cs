//-----------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace StyleCopShapes
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
        private double widthOfRectangle;
        private double heightOfRectangle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// Constructor sets lengths of sides and coordinates of left-bottom point of rectangle.
        /// </summary>
        /// <param name="bottomLeftCoordinate">Left-bottom point of rectangle.</param>
        /// <param name="widthOfRectangle">Length of top and bottom sides of rectangle.</param>
        /// <param name="heightOfRectangle">Length of left and right sides of rectangle.</param>
        public Rectangle(Point bottomLeftCoordinate, double widthOfRectangle, double heightOfRectangle)
        {
            this.BottomLeftCoordinate = bottomLeftCoordinate;
            this.WidthOfRectangle = widthOfRectangle;
            this.HeightOfRectangle = heightOfRectangle;
        }

        /// <summary>
        /// Gets or sets the bottom-left coordinate of this Rectangle class.
        /// </summary>
        public Point BottomLeftCoordinate { get; set; }

        /// <summary>
        /// Gets or sets the width of this Rectangle class.
        /// </summary>
        public double WidthOfRectangle
        {
            get 
            { 
                return this.widthOfRectangle; 
            }

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
        public double HeightOfRectangle
        {
            get 
            { 
                return this.heightOfRectangle; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be positive.");
                }

                this.heightOfRectangle = value;
            }
        }
        
        /// <summary>
        /// Method moves rectangle in appropriate direction.
        /// </summary>
        /// <param name="movementAlongX">Value that will change X coordinate of left-bottom point.</param>
        /// <param name="movementAlongY">Value that will change Y coordinate of left-bottom point.</param>
        /// <returns>Modified instance of the class.</returns>
        public Rectangle MoveAlongAxis(double movementAlongX, double movementAlongY)
        {
            return new Rectangle(new Point(this.BottomLeftCoordinate.X + movementAlongX, this.BottomLeftCoordinate.Y + movementAlongY), this.WidthOfRectangle, this.HeightOfRectangle);
        }

        /// <summary>
        /// Method changes size of rectangle.
        /// </summary>
        /// <param name="changedWidth">New value of width in rectangle.</param>
        /// <param name="changedHeight">New value of height in rectangle.</param>
        /// <returns>Modified instance of the class.</returns>
        public Rectangle Resize(double changedWidth, double changedHeight)
        {
            return new Rectangle(new Point(this.BottomLeftCoordinate.X, this.BottomLeftCoordinate.Y), this.WidthOfRectangle + changedWidth, this.HeightOfRectangle + changedHeight);
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
