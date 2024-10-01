using Moq;
using NUnit.Framework;

namespace ICT3101_Calculator.UnitTests
{
    public class AdditionalTest
    {
        private Calculator _calculator;

        private Mock<IFileReader> _mockFileReader;

        [SetUp]
        public void Setup()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockFileReader
                .Setup(fr => fr.Read("MagicNumbers.txt"))
                .Returns(new string[] { "1", "5", "10", "-1"});

            _calculator = new Calculator();
        }


        [Test]
        public void GenMagicNum_PositiveRead_ReturnsExpectedResult()
        {
            double result = _calculator.GenMagicNum(1, _mockFileReader.Object);
            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void GenMagicNum_NegativeRead_ReturnsExpectedResult()
        {
            double result = _calculator.GenMagicNum(3, _mockFileReader.Object);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GenMagicNum_InvalidInput_ReturnsZero()
        {
            double result = _calculator.GenMagicNum(10, _mockFileReader.Object);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
