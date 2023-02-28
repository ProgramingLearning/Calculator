using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Logic.Tests
{
    [TestClass]
    public class CalculatorValidatorTests
    {
        // sut = system under test
        private CalculatorValidator _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new CalculatorValidator();
        }

        [TestMethod]
        public void ValidateOperation_WhenOperationIsNone_ThrowsCalculatorException()
        {
            //Arrange
            var operation = Operation.None;

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ValidateOperation(operation));
        }
    }
}
