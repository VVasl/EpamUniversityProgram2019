//-----------------------------------------------------------------------
// <copyright file="Point.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------

namespace StyleCopShapes
{
    /// <summary>
    /// Represents an ordered pair of integer x- and y-coordinates that defines a point in a two-dimensional plane.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref ="Point"/> class.
        /// Assigns X and Y coordinates.
        /// </summary>
        /// <param name="x">Value to be assigned to X.</param>
        /// <param name="y">Value to be assigned to Y.</param>
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the x-coordinate of a point.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y-coordinate of a point.
        /// </summary>
        public double Y { get; set; }
    }
}
