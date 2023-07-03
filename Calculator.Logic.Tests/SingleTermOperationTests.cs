using Calculator.Domain.Request;
using Calculator.Domain.Response;
using Calculator.Logic;
using Calculator.Logic.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Calculator.Tests
{
    [TestClass]
    public class SingleTermOperationLogicTests
    {
        private Mock<ICalculatorError> calculatorErrorMock;
        private Mock<ICalculatorValidator> calculatorValidatorMock;
        private Mock<IStringToNumberConvertor> stringToNumberConverterMock;
        private SingleTermOperationLogic _sut;

        [TestInitialize]
        public void Setup()
        {
            calculatorErrorMock = new Mock<ICalculatorError>();
            calculatorValidatorMock = new Mock<ICalculatorValidator>();
            stringToNumberConverterMock = new Mock<IStringToNumberConvertor>();
            _sut = new SingleTermOperationLogic(calculatorErrorMock.Object, calculatorValidatorMock.Object, stringToNumberConverterMock.Object);
        }

        [TestMethod]
        public void IsPrime_ReturnsTrue_ForPrimeNumber()
        {
            // Arrange
            var operation = SingleTermOperation.IsPrime;
            var term = "7";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(7);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Is a Prime number", result.Message);
        }

        [TestMethod]
        public void IsPrime_ReturnsFalse_ForNonPrimeNumber()
        {
            // Arrange
            var operation = SingleTermOperation.IsPrime;
            var term = "9";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(9);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Is not a Prime number", result.Message);
        }

        [TestMethod]
        public void IsOddOrEven_ReturnsTrue_ForEvenNumber()
        {
            // Arrange
            var operation = SingleTermOperation.IsOddOrEven;
            var term = "4";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(4);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Is an Even number", result.Message);
        }

        [TestMethod]
        public void IsOddOrEven_ReturnsTrue_ForOddNumber()
        {
            // Arrange
            var operation = SingleTermOperation.IsOddOrEven;
            var term = "7";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(7);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Is an Odd number", result.Message);
        }

        [TestMethod]
        public void SquareRoot_ReturnsCorrectResult()
        {
            // Arrange
            var operation = SingleTermOperation.SquareRoot;
            var term = "9";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<double>(term)).Returns(9);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("3", result.Value);
        }

        [TestMethod]
        public void AbsoluteValue_ReturnsCorrectResult()
        {
            // Arrange
            var operation = SingleTermOperation.AbsoluteValue;
            var term = "-5";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<double>(term)).Returns(-5);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("5", result.Value);
        }

        [TestMethod]
        public void Reverse_ReturnsCorrectResult()
        {
            // Arrange
            var operation = SingleTermOperation.Reverse;
            var term = "12345";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(12345);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("54321", result.Value);
        }

        [TestMethod]
        public void IsPalindrome_ReturnsTrue_ForPalindromeNumber()
        {
            // Arrange
            var operation = SingleTermOperation.IsPalindrome;
            var term = "12321";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(12321);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Is a Palindrome number", result.Message);
        }

        [TestMethod]
        public void IsPalindrome_ReturnsFalse_ForNonPalindromeNumber()
        {
            // Arrange
            var operation = SingleTermOperation.IsPalindrome;
            var term = "12345";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(12345);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Is not a Palindrome number", result.Message);
        }

        [TestMethod]
        public void IsSuperpalindrome_ReturnsTrue_ForSuperPalindromeNumber()
        {
            // Arrange
            var operation = SingleTermOperation.IsSuperpalindrome;
            var term = "121";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(121);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Is a SuperPalindrome number", result.Message);
        }

        [TestMethod]
        public void IsSuperpalindrome_ReturnsFalse_ForNonSuperPalindromeNumber()
        {
            // Arrange
            var operation = SingleTermOperation.IsSuperpalindrome;
            var term = "123";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(123);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("Is not a SuperPalindrome number", result.Message);
        }

        [TestMethod]
        public void ChangeSign_ReturnsCorrectResult()
        {
            // Arrange
            var operation = SingleTermOperation.ChangeSign;
            var term = "5";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<double>(term)).Returns(5);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("-5", result.Value);
        }

        [TestMethod]
        public void Reverse_ReturnsZero_ForZeroInput()
        {
            // Arrange
            var operation = SingleTermOperation.Reverse;
            var term = "0";
            stringToNumberConverterMock.Setup(m => m.ReadTerm<int>(term)).Returns(0);

            // Act
            var result = _sut.DoSingleTermOperation(operation, term);

            // Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual("0", result.Value);
        }
    }
}
