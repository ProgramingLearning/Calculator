using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var termsList = new List<string>() { "5", "10", "20" };

            //Act
            //Assert
            Assert.ThrowsException<CalculatorException>(() => _sut.ReadTerm<float>(termsList));
        }
    }
}
