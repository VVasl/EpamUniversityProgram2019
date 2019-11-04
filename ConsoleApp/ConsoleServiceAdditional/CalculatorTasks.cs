
namespace ConsoleApp
{
    using System;
    using System.IO;
    using Common;
    using Calc; 

    public class CalculatorTasks : Tasks
    {
        public void CalculatorTaskConsole()
        {
            this.writer.Write("----------Calculator. Task 1: Read/write data from/to console");
            logger.Info("Calculator. Task 1: Read/write data from/to console.\n");
            try
            {
                Calculator expression = new Calculator(new ConsoleInputOutput());

                this.writer.Write("Enter first number:");
                double firstNumber = expression.Read();
                this.writer.Write("Enter second number:");
                double secondNumber = expression.Read();
                this.writer.Write("Choose an operation to perform:");
                this.writer.Write("\t1 - Addition, 2 - Subtraction, 3 - Multiplication, 4 - Division.");
                double option = expression.Read();

                double calculationResult = option switch
                {
                    1 => Calculator.Calculate(firstNumber, secondNumber, Calculator.Add),
                    2 => Calculator.Calculate(firstNumber, secondNumber, Calculator.Subtract),
                    3 => Calculator.Calculate(firstNumber, secondNumber, Calculator.Multiply),
                    4 => Calculator.Calculate(firstNumber, secondNumber, Calculator.Divide),
                    _ => throw new ArgumentException(message: "invalid value", paramName: nameof(option))
                };
                this.writer.Write($"The result of calculation : {calculationResult}\n\n");
            }
            catch(FormatException e)
            {
                logger.Error(e.Message);
            }

            catch(DivideByZeroException e)
            {
                logger.Error(e.Message);
            }
             
        }

        public void CalculatorTaskFile()
        {
            this.writer.Write("----------Calculator. Task 2: Read/write data from/to file");
            logger.Info("Calculator. Task 2: Read/write data from/to file.\n");
            try
            {
                Calculator expression = new Calculator(new FileInputOutput(configuration["inputFile"], configuration["outputFile"]));

                this.writer.Write("The first number:");
                double firstNumber = expression.Read(0);
                this.writer.Write(firstNumber);
                this.writer.Write("The second number:");
                double secondNumber = expression.Read(1);
                this.writer.Write(secondNumber);
                this.writer.Write("The operation to perform:");
                this.writer.Write("\t1 - Addition, 2 - Subtraction, 3 - Multiplication, 4 - Division.");
                double option = expression.Read(2);
                this.writer.Write(option);

                double calculationResult = option switch
                {
                    1 => Calculator.Calculate(firstNumber, secondNumber, Calculator.Add),
                    2 => Calculator.Calculate(firstNumber, secondNumber, Calculator.Subtract),
                    3 => Calculator.Calculate(firstNumber, secondNumber, Calculator.Multiply),
                    4 => Calculator.Calculate(firstNumber, secondNumber, Calculator.Divide),
                    _ => throw new ArgumentException(message: "invalid value", paramName: nameof(option))
                };

                this.writer.Write($"The result of calculation : {calculationResult}\n");
                expression.Write($"The result of calculation : {calculationResult}");
            }

            catch (FileNotFoundException fileEx)
            {
                logger.Info("File not found: " + fileEx.Message);
            }

            catch (IOException e)
            {
                logger.Error(e.Message);
            }

            catch (FormatException e)
            {
                logger.Error(e.Message);
            }

            catch (DivideByZeroException e)
            {
                logger.Error(e.Message);
            }
        }
    }
}

