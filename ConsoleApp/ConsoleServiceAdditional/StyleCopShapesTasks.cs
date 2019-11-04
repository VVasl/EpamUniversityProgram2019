namespace ConsoleApp
{
    using System;
    using StyleCopShapes;

    public class StyleCopShapesTasks : Tasks
    {
        public void StyleCopRectangleTask()
        {
            logger.Info("StyleCop. Task : Rectangles");
            writer.Write("\n\t\tStyleCop. Task : Rectangles");
            try
            {
                Rectangle rectangleOne = new Rectangle(new Point(2, 1), 7, 3);
                Rectangle rectangleTwo = new Rectangle(new Point(5, 3), 6, 4);

                writer.Write("\nThe data of first rectangle:");
                writer.Write(rectangleOne.ToString());
                writer.Write("\nMove rectangle along x-axis: 1. Move rectangle along y-axis: 7.");
                writer.Write("The data of modified first rectangle:");
                writer.Write(rectangleOne.MoveAlongAxis(1, 7).ToString());

                writer.Write("\nThe data of second rectangle:");
                writer.Write(rectangleTwo.ToString());
                writer.Write("\nRectangle resize. Width:3, Height:7. ");
                writer.Write("The data of modified second rectangle:");
                writer.Write(rectangleTwo.Resize(3, 7).ToString());

                Rectangles rectangles = new Rectangles(rectangleOne, rectangleTwo);
                writer.Write("\nFind Intersection of  rectangles: ");
                if (rectangles.DoShapesOverlap())
                {
                    writer.Write(rectangles.FindIntersectionOfShapes().ToString());

                    writer.Write("\nFind the smallest rectangle: ");
                    writer.Write(rectangles.FindTheSmallestRectangle().ToString());
                }
            }
            catch(ArgumentException ex)
            {
                logger.Error(ex.Message);
            }
        }

        public void StyleCopCircleTask()
        {
            logger.Info("StyleCop. Task : Circles");
            writer.Write("\n\t\tStyleCop. Task : Circles");

            try
            {
                Circle circleOne = new Circle(new Point(2, 1), 5);
                Circle circleTwo = new Circle(new Point(5, 3), 6);

                writer.Write("\nThe data of first circle:");
                writer.Write(circleOne.ToString());
                writer.Write("\nMove circle along x-axis: 1. Move rectangle along y-axis: 3.");
                writer.Write("The data of modified circle:");
                writer.Write(circleOne.MoveAlongAxis(0, 3).ToString());

                writer.Write("\nThe data of second circle:");
                writer.Write(circleTwo.ToString());
                writer.Write("\nCircle resize. Radius : 3.");
                writer.Write("The data of modified second circle:");
                writer.Write(circleTwo.Resize(3).ToString());

                Circles circles = new Circles(circleOne, circleTwo);
                writer.Write("\nFind Intersection of  circles: ");
                if (circles.DoShapesOverlap())
                {
                    writer.Write(circles.FindIntersectionOfShapes().ToString());
                }
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
