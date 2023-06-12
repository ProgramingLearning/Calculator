using Calculator.Domain.Request;
using Calculator.Domain.Response;
using Calculator.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Calculator.Logic.Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private CalculatorService _sut;
        private Mock<ICalculatorLogic> _calculatorLogicMock;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorLogicMock = new Mock<ICalculatorLogic>();
            _sut = new CalculatorService(_calculatorLogicMock.Object);
        }

        [TestMethod]
        public void GetCalculatorResponseForMultipleTermOperation_Should_Call_AddTerm_With_FirstTerm_From_ButtonClicked()
        {
            // Arrange
            var request = new CalculatorRequest
            {
                ButtonClicked = "1_1",
                CalculatorState = null
            };

            // Act
            _sut.GetCalculatorResponseForMultipleTermOperation(request);

            // Assert
            _calculatorLogicMock.Verify(mock => mock.AddTerm("1"), Times.Once);
        }

        [TestMethod]
        public void GetCalculatorResponseForMultipleTermOperation_Should_Call_SetCurrentOperation_With_Operation_From_ButtonClicked()
        {
            // Arrange
            var request = new CalculatorRequest
            {
                ButtonClicked = "1_2",
                CalculatorState = null
            };

            // Act
            _sut.GetCalculatorResponseForMultipleTermOperation(request);

            // Assert
            _calculatorLogicMock.Verify(mock => mock.SetCurrentOperation(Operation.Subtract), Times.Once);
        }

        [TestMethod]
        public void GetCalculatorResponseForMultipleTermOperation_Should_Call_DoMultipleTermOperation_When_ButtonClicked_Is_Equals()
        {
            // Arrange
            var request = new CalculatorRequest
            {
                ButtonClicked = "1_=",
                CalculatorState = null
            };

            // Act
            _sut.GetCalculatorResponseForMultipleTermOperation(request);

            // Assert
            _calculatorLogicMock.Verify(mock => mock.DoMultipleTermOperation(), Times.Once);
        }

        [TestMethod]
        public void GetCalculatorResponseForSingleTermOperation_Should_Call_AddTerm_With_FirstTerm_From_ButtonClicked()
        {
            // Arrange
            var request = new CalculatorRequest
            {
                ButtonClicked = "1_1",
                CalculatorState = null
            };

            // Act
            _sut.GetCalculatorResponseForSingleTermOperation(request);

            // Assert
            _calculatorLogicMock.Verify(mock => mock.AddTerm("1"), Times.Once);
        }

        [TestMethod]
        public void GetCalculatorResponseForSingleTermOperation_Should_Call_ProcessOperationForSingleTerm_With_Operation_From_ButtonClicked()
        {
            // Arrange
            var request = new CalculatorRequest
            {
                ButtonClicked = "term1_2",
                CalculatorState = null
            };

            // Act
            _sut.GetCalculatorResponseForSingleTermOperation(request);

            // Assert
            _calculatorLogicMock.Verify(mock => mock.SetCurrentOperation(Operation.Subtract), Times.Once);
        }

        [TestMethod]
        public void GetCalculatorResponseForSingleTermOperation_Should_Return_CalculatorResponse_With_CalculatorResult()
        {
            // Arrange
            var request = new CalculatorRequest
            {
                ButtonClicked = "term1_13",
                CalculatorState = null
            };

            // Mock the DoSingleTermOperation method
            var expectedResult = new CalculatorResult();
            _calculatorLogicMock.Setup(mock => mock.DoSingleTermOperation()).Returns(expectedResult);

            // Act
            var result = _sut.GetCalculatorResponseForSingleTermOperation(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult, result.CalculatorResult);
        }
    }
}
