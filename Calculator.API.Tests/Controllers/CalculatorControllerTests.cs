using Calculator.API.Controllers;
using Calculator.Domain.Request;
using Calculator.Domain.Response;
using Calculator.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Calculator.API.Tests.Controllers
{
    [TestClass]
    public class CalculatorControllerTests
    {
        private CalculatorController _sut;
        private Mock<ICalculatorLogic> _calculatorLogicMock;

        [TestInitialize]
        public void Setup()
        {
            _calculatorLogicMock = new Mock<ICalculatorLogic>();
            _sut = new CalculatorController(_calculatorLogicMock.Object);
        }

        [TestMethod]
        public void GetMultipleTermResponse_ValidInput_ReturnsOk()
        {
            // Arrange
            var calculatorRequest = new CalculatorRequest
            {
                ButtonClicked = "2_=",
                CalculatorState = new CalculatorState
                {
                    Terms = new List<string> { "1" },
                    CurrentOperation = Operation.Sum
                }
            };

            var expectedResponse = new CalculatorResponse
            {
                CalculatorState = new CalculatorState
                {
                    Terms = new List<string> { "1", "2" },
                    CurrentOperation = Operation.Sum
                },
                CalculatorResult = new CalculatorResult
                {
                    IsSuccess = true,
                    Message = "Result",
                    Value = "3"
                }
            };

            _calculatorLogicMock.Setup(x => x.GetCalculatorState()).Returns(calculatorRequest.CalculatorState);
            _calculatorLogicMock.Setup(x => x.DoMultipleTermOperation()).Returns(expectedResponse.CalculatorResult);

            // Act
            var result = _sut.GetMultipleTermResponse(calculatorRequest);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            var actualResponse = (CalculatorResponse)okResult.Value;

            Assert.AreEqual(expectedResponse.CalculatorResult.IsSuccess, actualResponse.CalculatorResult.IsSuccess);
            Assert.AreEqual(expectedResponse.CalculatorResult.Message, actualResponse.CalculatorResult.Message);
            Assert.AreEqual(expectedResponse.CalculatorResult.Value, actualResponse.CalculatorResult.Value);
        }

        [TestMethod]
        public void GetMultipleTermResponse_InvalidInput_ReturnsBadRequest()
        {
            // Arrange
            var calculatorRequest = new CalculatorRequest
            {
                ButtonClicked = "1",
                CalculatorState = new CalculatorState()
            };

            // Act
            var result = _sut.GetMultipleTermResponse(calculatorRequest);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));

            _calculatorLogicMock.Verify(x => x.AddTerm(It.IsAny<string>()), Times.Never);
            _calculatorLogicMock.Verify(x => x.SetCurrentOperation(It.IsAny<Operation>()), Times.Never);
            _calculatorLogicMock.Verify(x => x.DoMultipleTermOperation(), Times.Never);
        }

        [TestMethod]
        public void GetSingleTermResponse_ValidInput_ReturnsOk()
        {
            // Arrange
            var calculatorRequest = new CalculatorRequest
            {
                ButtonClicked = "1_13",
                CalculatorState = new CalculatorState()
            };

            var expectedResponse = new CalculatorResponse
            {
                CalculatorState = new CalculatorState(),
                CalculatorResult = new CalculatorResult
                {
                    IsSuccess = true,
                    Message = "Result",
                    Value = "-1"
                }
            };

            _calculatorLogicMock.Setup(x => x.DoSingleTermOperation()).Returns(expectedResponse.CalculatorResult);

            // Act
            var result = _sut.GetSingleTermResponse(calculatorRequest);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            var actualResponse = (CalculatorResponse)okResult.Value;

            Assert.AreEqual(expectedResponse.CalculatorResult.IsSuccess, actualResponse.CalculatorResult.IsSuccess);
            Assert.AreEqual(expectedResponse.CalculatorResult.Message, actualResponse.CalculatorResult.Message);
            Assert.AreEqual(expectedResponse.CalculatorResult.Value, actualResponse.CalculatorResult.Value);
        }

        [TestMethod]
        public void GetSingleTermResponse_InvalidInput_ReturnsBadRequest()
        {
            // Arrange
            var calculatorRequest = new CalculatorRequest
            {
                ButtonClicked = "a",
                CalculatorState = new CalculatorState()
            };

            // Act
            var result = _sut.GetSingleTermResponse(calculatorRequest);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));

            _calculatorLogicMock.Verify(x => x.AddTerm(It.IsAny<string>()), Times.Never);
            _calculatorLogicMock.Verify(x => x.SetCurrentOperation(It.IsAny<Operation>()), Times.Never);
            _calculatorLogicMock.Verify(x => x.DoMultipleTermOperation(), Times.Never);
        }
    }
}
