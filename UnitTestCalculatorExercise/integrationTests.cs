using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using CalculatorExercise;

namespace IntegrationTestProgram
{
    [TestClass]
    public class CalculatorIntegrationTests
    {
        private StringWriter _stringWriter;
        private StringReader _stringReader;
        private TextWriter _originalOutput;
        private TextReader _originalInput;

        [TestInitialize]
        public void Setup()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            _originalInput = Console.In;
            Console.SetOut(_stringWriter);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Console.SetOut(_originalOutput);
            Console.SetIn(_originalInput);
            _stringWriter.Dispose();
            if (_stringReader != null)
                _stringReader.Dispose();
        }

        [TestMethod]
        public void TestAdditionIntegration()
        {
            string input = "5\n3\n+\nexit\n";
            _stringReader = new StringReader(input);
            Console.SetIn(_stringReader);
            Program.Main(new string[] { });

            string output = _stringWriter.ToString();
            Assert.IsTrue(output.Contains("The result is: 8"));
        }

        [TestMethod]
        public void TestDivisionIntegration()
        {
            string input = "10\n2\n/\nexit\n";
            _stringReader = new StringReader(input);
            Console.SetIn(_stringReader);
            Program.Main(new string[] { });

            string output = _stringWriter.ToString();
            Assert.IsTrue(output.Contains("The result is: 5"));
        }

        [TestMethod]
        public void TestDivisionByZeroIntegration()
        {
            string input = "10\n0\n/\nexit\n";
            _stringReader = new StringReader(input);
            Console.SetIn(_stringReader);
            Program.Main(new string[] { });

            string output = _stringWriter.ToString();
            Assert.IsTrue(output.Contains("Cannot divide by zero"));
        }

        [TestMethod]
        public void TestInvalidInputIntegration()
        {
            string input = "abc\n3\n+\nexit\n";
            _stringReader = new StringReader(input);
            Console.SetIn(_stringReader);
            Program.Main(new string[] { });

            string output = _stringWriter.ToString();
            Assert.IsTrue(output.Contains("Invalid input. Please enter numeric values"));
        }

        [TestMethod]
        public void TestInvalidOperationIntegration()
        {
            string input = "5\n3\n#\nexit\n";
            _stringReader = new StringReader(input);
            Console.SetIn(_stringReader);
            Program.Main(new string[] { });

            string output = _stringWriter.ToString();
            Assert.IsTrue(output.Contains("Invalid operation"));
        }

        [TestMethod]
        public void TestMultipleOperationsIntegration()
        {
            string input = "5\n3\n+\n10\n2\n*\nexit\n";
            _stringReader = new StringReader(input);
            Console.SetIn(_stringReader);
            Program.Main(new string[] { });

            string output = _stringWriter.ToString();
            Assert.IsTrue(output.Contains("The result is: 8"));
            Assert.IsTrue(output.Contains("The result is: 20"));
        }
    }
}