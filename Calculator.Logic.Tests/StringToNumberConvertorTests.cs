using Calculator.Logic.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator.Logic.Errors;
using System.Collections.Generic;

namespace Calculator.Logic.Tests
{
    [TestClass]
    public class StringToNumberConvertorTests
    {
        // sut = system under test
        private StringToNumberConvertor _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new StringToNumberConvertor();
        }

        [TestMethod]
        public void ReadTerm_WhenTermsListIsEmpty_ReturnsDefaultValue()
        {
            //Arrange
            var termsList = new List<string>();
            double expected = default;

            //Act
            var actual = _sut.ReadTerm<double>(termsList);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadTerm_WhenTermsListHasValues_AndTriesToConvertToUnknownType_ThrowsCalculatorException()
        {
            //Arrange
            var termsList = new List<string>() { "5" };

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ReadTerm<float>(termsList));
        }

        [TestMethod]
        public void ReadTerm_WhenTermsListHasValues_AndTriesToConvertToDoubleType_ReturnListWithTermsOfDoubleType()
        {
            //Arrange
            var termsList = new List<string>() { "5" };
            double expected = 5;
            //Act
            var actual = _sut.ReadTerm<double>(termsList);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadTerm_WhenTermsListHasValues_AndTriesToConvertToIntType_ReturnListWithTermsOfIntType()
        {
            //Arrange
            var termsList = new List<string>() { "5" };
            int expected = 5;
            //Act
            var actual = _sut.ReadTerm<int>(termsList);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadTerm_WhenTermsListHasInvalidValues_AndTriesToConvertToDoubleType_ThrowsCalculatorException()
        {
            //Arrange
            var termsList = new List<string>() { "f" };

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ReadTerm<double>(termsList));
        }

        [TestMethod]
        public void ReadTerm_WhenTermsListHasInvalidValues_AndTriesToConvertToIntType_ThrowsCalculatorException()
        {
            //Arrange
            var termsList = new List<string>() { "3,2" };

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ReadTerm<int>(termsList));
        }

        [TestMethod]
        public void ReadTerms_WhenTermsListIsEmpty_ReturnsDefaultValue()
        {
            //Arrange
            //Arrange
            var termsList = new List<string>();

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ReadTerms<double>(termsList));
        }

        [TestMethod]
        public void ReadTerms_WhenTermsListHasValues_AndTriesToConvertToUnknownType_ThrowsCalculatorException()
        {
            //Arrange
            var termsList = new List<string>() { "5", "10", "20" };

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ReadTerms<float>(termsList));
        }

        [TestMethod]
        public void ReadTerms_WhenTermsListHasValues_AndTriesToConvertToIntType_ReturnListWithTermsOfIntType()
        {
            //Arrange
            var termsList = new List<string>() { "1", "2", "3" };
            var expected = new List<int>() { 1, 2, 3 };
            //Act
            var actual = _sut.ReadTerms<int>(termsList);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadTerms_WhenTermsListHasValues_AndTriesToConvertToDoubleType_ReturnListWithTermsOfDoubleType()
        {
            //Arrange
            var termsList = new List<string>() { "1", "2", "3" };
            var expected = new List<double>() { 1, 2, 3 };
            //Act
            var actual = _sut.ReadTerms<double>(termsList);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadTerms_WhenTermsListHasInvalidValues_AndTriesToConvertToDoubleType_ThrowsCalculatorException()
        {
            //Arrange
            var termsList = new List<string>() { "1", "2.7", "3,2", "f", "0874610846198562'29538561'29835'193812", "3,80986098609607608768760" };

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ReadTerms<double>(termsList));
        }

        [TestMethod]
        public void ReadTerms_WhenTermsListHasInvalidValues_AndTriesToConvertToIntType_ThrowsCalculatorException()
        {
            //Arrange
            var termsList = new List<string>() { "1", "2.7", "3,2" };

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ReadTerms<int>(termsList));
        }
    }
}
