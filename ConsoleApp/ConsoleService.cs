using System;
using System.Collections.Generic;
using StructsAndEnums.Enums;
using StructsAndEnums.Structs;
using System.Text;

namespace ConsoleApp
{
    class ConsoleService: IConsoleService
    {
        public void RunTasks()
        {
            List<Action> functions = new List<Action>();
            functions.Add(RunPersonTask);
            functions.Add(RunRectangleTask);
            functions.Add(RunMonthNameTask);
            functions.Add(RunOrderedColorsTask);
            functions.Add(RunMinMaxLongValueTask);

            foreach (Action func in functions)
                func();
        }

        private void RunPersonTask()
        {
            try
            {
                Console.Write("-----Task1-----\n\n");
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter surname: ");
                string surname = Console.ReadLine();

                Console.Write("Enter age: ");
                int age = Int32.Parse(Console.ReadLine());


                Console.Write("Enter age value: ");
                int ageValue = Convert.ToInt32(Console.ReadLine());

                Person ann = new Person(name, surname, age);
                string o = ann.DisplayInfoAge(ageValue);
                Console.WriteLine(o);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void RunRectangleTask()
        {
            try
            {
                Console.Write("\n-----Task2-----\n\n");
                Rectangle rect = new Rectangle();

                Console.Write("Enter width of the rectangle : ");
                rect.Width = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter height of the rectangle : ");
                rect.Height = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter x coordinate of the rectangle: ");
                rect.X = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter y coordinate of the rectangle: ");
                rect.Y = Convert.ToDouble(Console.ReadLine());

                double perim = rect.Perimeter();
                Console.WriteLine($"Perimeter of the rectangle is: {perim}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void RunMonthNameTask()
        {
            try
            {
                Console.Write("\n-----Task3-----\n\n");
                Console.Write("Enter month number: ");
                int n = Convert.ToInt32(Console.ReadLine());
                string monthName = MonthName.GetMonth(n);
                Console.WriteLine(monthName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void RunOrderedColorsTask()
        {
            try
            {
                Console.Write("\n-----Task4-----\n\n");
                Colors color = Colors.Red;
                foreach (var value in color.OrderColorsAsc())
                {
                    Console.WriteLine("{0}    {1}", (int)value, ((Colors)value));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void RunMinMaxLongValueTask()
        {
            try
            {
                Console.Write("\n-----Task5-----\n\n");
                long x = (long)RangeLong.Max;
                long y = (long)RangeLong.Min;
                Console.WriteLine("Maximum value for a long int = {0}", x);
                Console.WriteLine("Minimum value for a long int = {0}", y);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }

}
