using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Calculator.Logic.Tests
{
    [TestClass]
    public class CalculatorLogicTests
    {
        private Mock<ICalculatorError> _calculatorErrorMock;
        private Mock<ICalculatorValidator> _calculatorValidatorMock;
        private Mock<IStringToNumberConvertor> _stringToNumberConvertorMock;
        private CalculatorLogic _sut;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorErrorMock = new Mock<ICalculatorError>();
            _calculatorValidatorMock = new Mock<ICalculatorValidator>();
            _stringToNumberConvertorMock = new Mock<IStringToNumberConvertor>();

            _sut = new CalculatorLogic(
                _calculatorErrorMock.Object, 
                _calculatorValidatorMock.Object,
                _stringToNumberConvertorMock.Object);
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForIsPrime_AndOperationIsIsPrime_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("7");
            _sut.SetCurrentOperation(Operation.IsPrime);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(7);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("7", actual.Value);
            Assert.AreEqual("Is a Prime number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsPrime), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForIsPrime_AndOperationIsIsPrime_AndNumberIsNot_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("10");
            _sut.SetCurrentOperation(Operation.IsPrime);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(10);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("10", actual.Value);
            Assert.AreEqual("Is not a Prime number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsPrime), Times.Once());
        }
    }
}
