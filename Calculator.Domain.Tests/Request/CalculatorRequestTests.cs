using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Domain.Request;

namespace Calculator.Domain.Tests.Request
{
    [TestClass]
    public class CalculatorRequestTests
    {
        [TestMethod]
        public void CalculatorRequest_ButtonClicked_SetAndGetCorrectly()
        {
            // Arrange
            string buttonClicked = "2_=";
            var calculatorState = new CalculatorState();

            // Act
            var calculatorRequest = new CalculatorRequest
            {
                ButtonClicked = buttonClicked,
                CalculatorState = calculatorState
            };

            // Assert
            Assert.AreEqual(buttonClicked, calculatorRequest.ButtonClicked);
        }

        [TestMethod]
        public void CalculatorRequest_CalculatorState_SetAndGetCorrectly()
        {
            // Arrange
            string buttonClicked = "2_=";
            var calculatorState = new CalculatorState();

            // Act
            var calculatorRequest = new CalculatorRequest
            {
                ButtonClicked = buttonClicked,
                CalculatorState = calculatorState
            };

            // Assert
            Assert.AreEqual(calculatorState, calculatorRequest.CalculatorState);
        }
    }
}
