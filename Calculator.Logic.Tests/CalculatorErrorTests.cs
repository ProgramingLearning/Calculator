using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Calculator.Logic.Tests
{
    [TestClass]
    public class CalculatorErrorTests
    {
        // sut = system under test
        private CalculatorError _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new CalculatorError();
        }

        //[TestMethod]
        //public void HandleCalculatorException_WhenOperationIsNone_ThrowsCalculatorException()
        //{
        //    //Arrange
        //    var operation = Operation.None;

        //    //Act
        //    //Assert
        //    Assert.ThrowsException<CalculatorException>(() => _sut.HandleCalculatorException(Error.None));
        //    Assert.ThrowsException<CalculatorError>(() => _sut.HandleCalculatorException(operation));
        //}
    }
}
