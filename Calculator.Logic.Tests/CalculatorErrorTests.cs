using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Calculator.Logic.Errors;

namespace Calculator.Logic.Tests
{
    [TestClass]
    public class CalculatorErrorTests
    {
        private Mock<ICalculatorLogic> _calculatorLogicMock;
        private Mock<ICalculatorValidator> _calculatorValidatorMock;
        private Mock<IStringToNumberConvertor> _stringToNumberConvertorMock;
        private CalculatorError _sut;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorLogicMock = new Mock<ICalculatorLogic>();
            _calculatorValidatorMock = new Mock<ICalculatorValidator>();
            _stringToNumberConvertorMock = new Mock<IStringToNumberConvertor>();

            _sut = new CalculatorError();
        }

        [TestMethod]
        public void HandleCalculatorException_ReturnsCorrectErrorMessage_ForDivideBy0()
        {
            // Arrange
            var calculatorError = new CalculatorError();
            var calculatorException = new CalculatorException(Error.DivideBy0);

            // Act
            var actual = calculatorError.HandleCalculatorException(calculatorException);

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "Can not divide by 0");
        }

        [TestMethod]
        public void HandleCalculatorException_ReturnsCorrectErrorMessage_NoOperationSelected()
        {
            // Arrange
            var calculatorError = new CalculatorError();
            var calculatorException = new CalculatorException(Error.NoOperationSelected);

            // Act
            var actual = calculatorError.HandleCalculatorException(calculatorException);

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "Select operation: +, -, *or / ");
        }

        [TestMethod]
        public void HandleCalculatorException_ReturnsCorrectErrorMessage_IsNotAnInteger()
        {
            // Arrange
            var calculatorError = new CalculatorError();
            var calculatorException = new CalculatorException(Error.IsNotAnInteger);
            // Act
            var actual = calculatorError.HandleCalculatorException(calculatorException);

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "The number is not an Integer");
        }

        [TestMethod]
        public void HandleCalculatorException_ReturnsCorrectErrorMessage_ToFewTerms()
        {
            // Arrange
            var calculatorError = new CalculatorError();
            var calculatorException = new CalculatorException(Error.ToFewTerms);
            // Act
            var actual = calculatorError.HandleCalculatorException(calculatorException);

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "To few terms");
        }

        [TestMethod]
        public void HandleCalculatorException_ReturnsCorrectErrorMessage_IsNotADouble()
        {
            // Arrange
            var calculatorError = new CalculatorError();
            var calculatorException = new CalculatorException(Error.IsNotADouble);
            // Act
            var actual = calculatorError.HandleCalculatorException(calculatorException);

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "The number is not a Double");
        }

        [TestMethod]
        public void HandleCalculatorException_ReturnsCorrectErrorMessage_ZeroCantBeNegativeOrPositive()
        {
            // Arrange
            var calculatorError = new CalculatorError();
            var calculatorException = new CalculatorException(Error.ZeroCantBeNegativeOrPositive);
            // Act
            var actual = calculatorError.HandleCalculatorException(calculatorException);

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "Zero can´t be negative or positive");
        }

        [TestMethod]
        public void HandleCalculatorException_ReturnsCorrectErrorMessage_TypeOfDateNotImplemented()
        {
            // Arrange
            var calculatorError = new CalculatorError();
            var calculatorException = new CalculatorException(Error.TypeOfDateNotImplemented);
            // Act
            var actual = calculatorError.HandleCalculatorException(calculatorException);

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "Type of date not implemented");
        }

        [TestMethod]
        public void HandleCalculatorException_ReturnsCorrectErrorMessage_NoTermSelected()
        {
            // Arrange
            var calculatorError = new CalculatorError();
            var calculatorException = new CalculatorException(Error.NoTermSelected);
            // Act
            var actual = calculatorError.HandleCalculatorException(calculatorException);

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "No term selected");
        }

        [TestMethod]
        public void HandleCalculatorException_ReturnsCorrectErrorMessage_IsNotAPositiveInteger()
        {
            // Arrange
            var calculatorError = new CalculatorError();
            var calculatorException = new CalculatorException(Error.IsNotAPositiveInteger);
            // Act
            var actual = calculatorError.HandleCalculatorException(calculatorException);

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "The number is not a Positive Integer");
        }



    }
}
