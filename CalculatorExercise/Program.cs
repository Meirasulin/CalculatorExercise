using System;
using System.Text.RegularExpressions;

namespace CalculatorExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            while (true)
            {
                Console.WriteLine("Enter an arithmetic expression (or type 'exit' to quit):");
                string arithmeticExpression = Console.ReadLine();
                if (arithmeticExpression.ToLower() == "exit") break;

                try
                {
                    string arithmeticExpressionPattern = @"^(-?\d+\.?\d*)([\+\-\*\/])(-?\d+\.?\d*)$";
                    Match match = Regex.Match(arithmeticExpression, arithmeticExpressionPattern);

                    if (!match.Success)
                    {
                        throw new ArgumentException("Invalid input. Please enter valid arithmetic expression.");
                    }
                    double num1 = double.Parse(match.Groups[1].Value);
                    double num2 = double.Parse(match.Groups[3].Value);
                    string operation = match.Groups[2].Value;
                    double result = 0;

                    switch (operation)
                    {
                        case "+":
                            result = calculator.Add(num1, num2);
                            break;
                        case "-":
                            result = calculator.Subtract(num1, num2);
                            break;
                        case "*":
                            result = calculator.Multiply(num1, num2);
                            break;
                        case "/":
                            result = calculator.Divide(num1, num2);
                            break;
                        default:
                            Console.WriteLine("Invalid operation.");
                            continue;
                    }

                    Console.WriteLine($"The result is: {result}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
