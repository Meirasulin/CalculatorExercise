using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorExercise;
using System.IO;
//using Xunit;

namespace IntegrationTestCalculatorExercise
{
    [TestClass]
    public class CalculatorProgramIntegrationTest
    {
        private Program _program;

        [TestInitialize]
        public void Setup()
        {
            _program = new Program();
        }

        [TestMethod]
        public void Test_Program_Addition()
        {
            var calculator = new Calculator();

            var input = "2\n3\n+\n";
            var output = new StringWriter();
            Console.SetOut(output);
            var inputReader = new StringReader(input);
            Console.SetIn(inputReader);

            Program.Main(new string[] { });

            Assert.Contains("The result is: 5", output.ToString());
        }

    }
}
