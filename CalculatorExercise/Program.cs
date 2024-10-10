using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
        while (true)
        {
            Console.WriteLine("Enter two numbers (or type 'exit' to quit):");
            string input1 = Console.ReadLine();
            if (input1.ToLower() == "exit") break;
            string input2 = Console.ReadLine();
            if (input2.ToLower() == "exit") break;

            Console.WriteLine("Enter the operation (+, -, *, /):");
            string operation = Console.ReadLine();
            if (operation.ToLower() == "exit") break;

            try
            {
                double num1 = double.Parse(input1);
                double num2 = double.Parse(input2);
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
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numeric values.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        }
    }
}
