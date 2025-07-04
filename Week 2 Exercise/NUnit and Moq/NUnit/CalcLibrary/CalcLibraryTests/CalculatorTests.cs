using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibraryTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Teardown()
        {
            _calculator.AllClear();
        }

        // As asked for in the exercise, only the Addition test is uncommented.
        [TestCase(10, 5, 15)]
        [TestCase(-2, -3, -5)]
        [TestCase(0, 0, 0)]
        public void Addition_ReturnsExpectedResult(double a, double b, double expected)
        {
            var result = _calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        // uncomment the following tests to run them

        /*
        [TestCase(10, 5, 5)]
        [TestCase(0, 5, -5)]
        [TestCase(-3, -2, -1)]
        public void Subtraction_ReturnsExpectedResult(double a, double b, double expected)
        {
            var result = _calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(2, 3, 6)]
        [TestCase(-4, 5, -20)]
        [TestCase(0, 7, 0)]
        public void Multiplication_ReturnsExpectedResult(double a, double b, double expected)
        {
            var result = _calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(-8, -2, 4)]
        public void Division_ReturnsExpectedResult(double a, double b, double expected)
        {
            var result = _calculator.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _calculator.Division(10, 0));
            Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
        }

        [Test]
        public void GetResultProperty_ReturnsLastOperationResult()
        {
            _calculator.Addition(5, 5);
            Assert.That(_calculator.GetResult, Is.EqualTo(10));
        }

        [Test]
        public void AllClear_ResetsResultToZero()
        {
            _calculator.Addition(3, 4); // Perform an operation
            _calculator.AllClear(); // clear the result
            Assert.That(_calculator.GetResult, Is.EqualTo(0)); // check the state is reset
        } */
    }
}
