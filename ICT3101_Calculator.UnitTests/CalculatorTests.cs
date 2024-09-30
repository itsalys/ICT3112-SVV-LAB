using Moq;
using NUnit.Framework;

namespace ICT3101_Calculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockFileReader
                .Setup(fr => fr.Read("MagicNumbers.txt"))
                .Returns(new string[] { "1", "5", "10"});

            _calculator = new Calculator();
        }

        // Addition Tests
        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            double result = _calculator.Add(10, 20);
            Assert.That(result, Is.EqualTo(30));
        }

        // Task 13
        // Subtraction Tests
        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToDifference()
        {
            double result = _calculator.Subtract(20, 10);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void Subtract_WhenResultIsNegative_ResultEqualToNegativeDifference()
        {
            double result = _calculator.Subtract(10, 20);
            Assert.That(result, Is.EqualTo(-10));
        }

        // Multiplication Tests
        [Test]
        public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToProduct()
        {
            double result = _calculator.Multiply(10, 5);
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void Multiply_WhenMultiplyingByZero_ResultEqualToZero()
        {
            double result = _calculator.Multiply(10, 0);
            Assert.That(result, Is.EqualTo(0));
        }

        // Division Tests
        [Test]
        public void Divide_WhenDividingTwoNumbers_ResultEqualToQuotient()
        {
            double result = _calculator.Divide(20, 4);
            Assert.That(result, Is.EqualTo(5));
        }

        // [Test]
        // public void Divide_WhenDividingByZero_ShouldThrowArgumentException()
        // {
        //     Assert.That(() => _calculator.Divide(10, 0), Throws.ArgumentException);
        // }

        // Task 14
        // [Test]
        // [TestCase(0, 0)]
        // [TestCase(0, 10)]
        // [TestCase(10, 0)]
        // public void Divide_WithZerosAsInputs_ShouldThrowArgumentException(double a, double b)
        // {
        //     Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
        // }

        // Task 15
        // Factorial Tests
        [Test]
        public void Factorial_WhenGivenZero_ShouldReturnOne()
        {
            double result = _calculator.Factorial(0);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Factorial_WhenGivenPositiveNumber_ShouldReturnFactorial()
        {
            double result = _calculator.Factorial(5);
            Assert.That(result, Is.EqualTo(120)); // 5! = 120
        }

        [Test]
        public void Factorial_WhenGivenNegativeNumber_ShouldThrowArgumentException()
        {
            Assert.That(() => _calculator.Factorial(-5), Throws.ArgumentException);
        }

        // Task 16

        // Test for area of triangle
        [Test]
        public void AreaOfTriangle_WhenGivenHeightAndBase_ShouldReturnCorrectArea()
        {
            double height = 10;
            double baseLength = 5;

            double result = _calculator.AreaOfTriangle(height, baseLength);

            Assert.That(result, Is.EqualTo(25)); // Formula: (height * baseLength) / 2
        }

        // Test for area of circle
        [Test]
        public void AreaOfCircle_WhenGivenRadius_ShouldReturnCorrectArea()
        {
            double radius = 7;

            double result = _calculator.AreaOfCircle(radius);

            Assert.That(result, Is.EqualTo(Math.PI * Math.Pow(radius, 2))); // Formula: π * r^2
        }

        // Task 17 - UnknownFunctionA Tests
        [Test]
        public void UnknownFunctionA_WhenGivenTest0_Result()
        {
            double result = _calculator.UnknownFunctionA(5, 5);
            Assert.That(result, Is.EqualTo(120)); // 5! = 120
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest1_Result()
        {
            double result = _calculator.UnknownFunctionA(5, 4);
            Assert.That(result, Is.EqualTo(120)); // 5! = 120
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest2_Result()
        {
            double result = _calculator.UnknownFunctionA(5, 3);
            Assert.That(result, Is.EqualTo(60)); // 5! / (5 - 3) = 120 / 2 = 60
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest3_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.UnknownFunctionA(-4, 5), Throws.ArgumentException);
        }

        [Test]
        public void UnknownFunctionA_WhenGivenTest4_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.UnknownFunctionA(4, 5), Throws.ArgumentException);
        }

        // Task 17 - UnknownFunctionB Tests
        [Test]
        public void UnknownFunctionB_WhenGivenTest0_Result()
        {
            double result = _calculator.UnknownFunctionB(5, 5);
            Assert.That(result, Is.EqualTo(1)); // 5! / 5! = 1
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest1_Result()
        {
            double result = _calculator.UnknownFunctionB(5, 4);
            Assert.That(result, Is.EqualTo(5)); // Factorial-based calculation gives 5
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest2_Result()
        {
            double result = _calculator.UnknownFunctionB(5, 3);
            Assert.That(result, Is.EqualTo(10)); // Factorial-based calculation gives 10
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest3_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.UnknownFunctionB(-4, 5), Throws.ArgumentException);
        }

        [Test]
        public void UnknownFunctionB_WhenGivenTest4_ResultThrowArgumentException()
        {
            Assert.That(() => _calculator.UnknownFunctionB(4, 5), Throws.ArgumentException);
        }

        [Test]
        public void GenMagicNum_PositiveInput_ReturnsExpectedResult()
        {
            double result = _calculator.GenMagicNum(1, _mockFileReader.Object);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void GenMagicNum_InvalidInput_ReturnsZero()
        {
            double result = _calculator.GenMagicNum(3, _mockFileReader.Object);
            Assert.That(result, Is.EqualTo(2));
        }
    }
}
