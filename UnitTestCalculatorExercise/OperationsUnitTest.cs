using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculatorExercise;

namespace UnitTestCalculatorExercise
{
    [TestClass]
    public class OperationsUnitTest
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator();
        }
        [TestMethod]
        public void Given_TwoNumbers_When_Adding_Then_ReturnsSum()
        {
            double result;
            result = _calculator.Add(3, 2);
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void Given_TwoNumbers_When_Subtracting_Then_ReturnsDifference()
        {
            double result;
            result = _calculator.Subtract(7, 5);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void Given_TwoNumbers_When_Multiplying_Then_ReturnsProduct()
        {
            double result;
            result = _calculator.Multiply(3, 5);
            Assert.AreEqual(15, result);
        }
        [TestMethod]
        public void Given_TwoNumbers_When_Dividing_Then_ReturnsQuotient()
        {
            double result;
            result = _calculator.Divide(10, 5);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Given_DivisorIsZero_When_Dividing_Then_ThrowsDivideByZeroException()
        {
            double result;
            result = _calculator.Divide(10, 0);
        }
        [TestMethod]
        public void Given_NegativeAndPositiveNumber_When_Adding_Then_ReturnsCorrectSum()
        {
            double result;
            result = _calculator.Add(10, -5);
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void Given_ZeroAndPositiveNumber_When_Adding_Then_ReturnsPositiveNumber()
        {
            double result;
            result = _calculator.Add(10, 0);
            Assert.AreEqual(10, result);
        }
        [TestMethod]
        public void Given_NegativeAndPositiveNumber_When_Subtracting_Then_ReturnsCorrectDifference()
        {
            double result;
            result = _calculator.Subtract(-10, 5);
            Assert.AreEqual(-15, result);
        }
        [TestMethod]
        public void Given_ZeroAndPositiveNumber_When_Subtracting_Then_ReturnsNegativeOfPositiveNumber()
        {
            double result;
            result = _calculator.Subtract(0, 10);
            Assert.AreEqual(-10, result);
        }
        [TestMethod]
        public void Given_NegativeAndPositiveNumber_When_Multiplying_Then_ReturnsNegativeProduct()
        {
            double result;
            result = _calculator.Multiply(-10, 2);
            Assert.AreEqual(-20, result);
        }
        [TestMethod]
        public void Given_AnyNumberAndZero_When_Multiplying_Then_ReturnsZero()
        {
            double result;
            result = _calculator.Multiply(10, 0);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Given_NegativeAndPositiveNumber_When_Dividing_Then_ReturnsNegativeQuotient()
        {
            double result;
            result = _calculator.Divide(-10, 5);
            Assert.AreEqual(-2, result);
        }

    }
}
