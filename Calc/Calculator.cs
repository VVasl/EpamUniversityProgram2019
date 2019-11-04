using System;

namespace Calc
{
    using Common;
    public class Calculator
    {
        private IInputOutput type;
        public Calculator(IInputOutput type)
        {
            this.type = type;
        }

        public static double Calculate(double firstNumber, double secondNumber, Func<double, double, double> operation)
        {
            return operation(firstNumber, secondNumber);
        }
        public static double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public static double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public static double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public static double Divide(double firstNumber, double secondNumber)
        {
            if(secondNumber == 0)
            {
                throw new DivideByZeroException($"Division of {firstNumber} by zero.");
            }
            return firstNumber / secondNumber;
        }

        public double Read()
        {
            if (!double.TryParse(this.type.Read(), out double number))
            {
                throw new FormatException($"Unable to parse '{nameof(number)}'");
            }

            return number;
        }

        public double Read(int n)
        {
            string[] values = this.type.Read().Split(' ');

            if (!double.TryParse(values[n], out double number))
            {
                throw new FormatException($"Unable to parse '{nameof(number)}'");
            }

            return number;
        }

        public void Write(object obj)
        {
            this.type.Write(obj);
        }
    } 
}
