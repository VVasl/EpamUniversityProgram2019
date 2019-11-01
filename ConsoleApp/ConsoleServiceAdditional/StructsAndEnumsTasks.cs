using System;
using StructsAndEnums.Enums;
using StructsAndEnums.Structs;
using Common;

namespace ConsoleApp
{
    public class StructsAndEnumsTasks
    {
        private IWriter writer;

        public StructsAndEnumsTasks()
        {
            this.writer = new ConsoleInputOutput();
        }
        public void RunPersonTask()
        {
            try
            {
                writer.Write("-----Task1-----\n\n");
                writer.Write("Enter name: ");
                string name = Console.ReadLine();

                writer.Write("Enter surname: ");
                string surname = Console.ReadLine();

                writer.Write("Enter age: ");
                int age = Int32.Parse(Console.ReadLine());


                writer.Write("Enter age value: ");
                int ageValue = Convert.ToInt32(Console.ReadLine());

                Person ann = new Person(name, surname, age);
                string o = ann.DisplayInfoAge(ageValue);
                writer.Write(o);
            }

            catch (Exception e)
            {
                writer.Write(e.Message);
            }
        }

        public void RunRectangleTask()
        {
            try
            {
                writer.Write("\n-----Task2-----\n\n");
                Rectangle rect = new Rectangle();

                writer.Write("Enter width of the rectangle : ");
                rect.Width = Convert.ToDouble(Console.ReadLine());

                writer.Write("Enter height of the rectangle : ");
                rect.Height = Convert.ToDouble(Console.ReadLine());

                writer.Write("Enter x coordinate of the rectangle: ");
                rect.X = Convert.ToDouble(Console.ReadLine());

                writer.Write("Enter y coordinate of the rectangle: ");
                rect.Y = Convert.ToDouble(Console.ReadLine());

                double perim = rect.Perimeter();
                writer.Write($"Perimeter of the rectangle is: {perim}");

            }

            catch (ArgumentException e)
            {
                this.writer.Write(e.Message);
            }

            catch (Exception e)
            {
                writer.Write(e.Message);
            }
        }

        public void RunMonthNameTask()
        {
            try
            {
                writer.Write("\n-----Task3-----\n\n");
                writer.Write("Enter month number: ");
                int n = Convert.ToInt32(Console.ReadLine());
                string monthName = MonthName.GetMonth(n);
                writer.Write(monthName);
            }
            catch (Exception e)
            {
                writer.Write(e.Message);
            }
        }

        public void RunOrderedColorsTask()
        {
            writer.Write("\n-----Task4-----\n\n");
            Colors color = Colors.Red;
            foreach (var value in color.OrderColorsAsc())
            {
                writer.Write($"{(int)value}    {(Colors)value}");
            }
        }

        public void RunMinMaxLongValueTask()
        {
            writer.Write("\n-----Task5-----\n\n");
            long x = (long)RangeLong.Max;
            long y = (long)RangeLong.Min;
            writer.Write($"Maximum value for a long int = {x}");
            writer.Write($"Minimum value for a long int = {y}");
        }
    }
}
