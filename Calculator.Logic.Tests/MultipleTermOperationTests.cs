using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Calculator.Logic.Errors;
using Calculator.Domain.Request;
using Calculator.Domain.Response;

namespace Calculator.Logic.Tests
{
    [TestClass]
    public class MultipleTermOperationLogicTests
    {
        private Mock<ICalculatorError> _calculatorErrorMock;
        private Mock<ICalculatorValidator> _calculatorValidatorMock;
        private Mock<IStringToNumberConvertor> _stringToNumberConvertorMock;
        private MultipleTermOperationLogic _sut;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorErrorMock = new Mock<ICalculatorError>();
            _calculatorValidatorMock = new Mock<ICalculatorValidator>();
            _stringToNumberConvertorMock = new Mock<IStringToNumberConvertor>();

            _sut = new MultipleTermOperationLogic(
                _calculatorErrorMock.Object,
                _calculatorValidatorMock.Object,
                _stringToNumberConvertorMock.Object);
        }
        
        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForSum_AndOperationIsSum_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81, 2");
            _sut.SetCurrentOperation(MultipleTermOperation.Sum);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 81, 2 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("83", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateMultipleTermOperation(MultipleTermOperation.Sum), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForSubtract_AndOperationIsSubtract_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81, 2");
            _sut.SetCurrentOperation(MultipleTermOperation.Subtract);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 81, 2 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("79", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateMultipleTermOperation(MultipleTermOperation.Subtract), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForMultiply_AndOperationIsMultiply_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81, 2");
            _sut.SetCurrentOperation(MultipleTermOperation.Multiply);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 81, 2 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("162", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateMultipleTermOperation(MultipleTermOperation.Multiply), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForDivide_AndOperationIsDivide_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81, 3");
            _sut.SetCurrentOperation(MultipleTermOperation.Divide);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 81, 3 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("27", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateMultipleTermOperation(MultipleTermOperation.Divide), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForPower_AndOperationIsPower_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("2, 3");
            _sut.SetCurrentOperation(MultipleTermOperation.Power);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 2, 3 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("8", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateMultipleTermOperation(MultipleTermOperation.Power), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_HandleErrorsWithTryAndCatchAndDoCalculation_CallHandleCalculatorException_WhenCalculatorExceptionThrown()
        {
            //Arrage
            _sut.AddTerm("2, 0");
            _sut.SetCurrentOperation(MultipleTermOperation.Divide);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 2, 0 });
            var calculatorException = new CalculatorException(Error.DivideBy0);
            _calculatorValidatorMock.Setup(x => x.ValidateMultipleTermOperation(It.IsAny<MultipleTermOperation>())).Throws(calculatorException);

            //Act
            var actual = _sut.DoMultipleTermOperation();

            // Assert
            _calculatorErrorMock.Verify(x => x.HandleCalculatorException(calculatorException), Times.Once);
        }

        [TestMethod]
        public void DoMultipleTermOperation_DoCalculation_DefaultCase_ReturnsEmptyCalculatorResult()
        {
            // Arrange
            _sut.AddTerm("5");
            _sut.SetCurrentOperation(MultipleTermOperation.None);

            // Act
            CalculatorResult actual = _sut.DoMultipleTermOperation();

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.IsNull(actual.Value);
            Assert.IsNull(actual.Message);
        }

        [TestMethod]
        public void GetCurrentOperation_ShouldReturnCurrentOperation()
        {
            _sut.AddTerm("2, 0");
            _sut.SetCurrentOperation(MultipleTermOperation.Sum);

            // Act
            var actual = _sut.GetCurrentOperation();

            // Assert
            Assert.AreEqual(MultipleTermOperation.Sum, actual);
        }

        [TestMethod]
        public void ShouldPerformOperationForCurrentTerms_Should_Return_False_When_NewOperation_Equals_CurrentOperation()
        {
            // Arrange
            _sut.SetCurrentOperation(MultipleTermOperation.Sum);

            // Act
            var actual = _sut.ShouldPerformOperationForCurrentTerms(MultipleTermOperation.Sum);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldPerformOperationForCurrentTerms_Should_Return_False_When_Terms_Count_Is_Less_Than_2()
        {
            // Arrange
            _sut.SetCurrentOperation(MultipleTermOperation.Sum);
            _sut.AddTerm("1");

            // Act
            var actual = _sut.ShouldPerformOperationForCurrentTerms(MultipleTermOperation.Multiply);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldPerformOperationForCurrentTerms_Should_Return_True_When_NewOperation_Does_Not_Equal_CurrentOperation_And_Terms_Count_Is_Greater_Than_1()
        {
            // Arrange
            _sut.SetCurrentOperation(MultipleTermOperation.Sum);
            _sut.AddTerm("1");
            _sut.SetCurrentOperation(MultipleTermOperation.Subtract);
            _sut.AddTerm("2");

            // Act
            var actual = _sut.ShouldPerformOperationForCurrentTerms(MultipleTermOperation.Multiply);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
