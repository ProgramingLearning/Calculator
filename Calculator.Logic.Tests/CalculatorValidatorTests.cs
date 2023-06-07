using Calculator.Domain.Request;
using Calculator.Logic.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Calculator.Logic.Tests
{
    [TestClass]
    public class CalculatorValidatorTests
    {
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

        [TestMethod]
        public void ValidateTermsForMultipleTermsOperation_WhenAreLessThenTwoTerms_ThrowsCalculatorException()
        {
            //Arrange
            var terms = new List<double>();

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ValidateTermsForMultipleTermsOperation(terms));
        }

        [TestMethod]
        public void ValidateTermsForDivision_WhenAnyOfTermsExceptForFirstOneIsZero_ThrowsCalculatorException()
        {
            //Arrange
            var terms = new List<double>() { 5, 5, 3, 4, 5, 0, 9, 10, 45 };

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ValidateTermsForDivision(terms));
        }

        [TestMethod]
        public void ValidateTermsForDivision_WhenAreLessThanTwoTerms_ThrowsCalculatorException()
        {
            //Arrange
            var terms = new List<double>() { 1 };

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ValidateTermsForDivision(terms));
        }
    }
}
