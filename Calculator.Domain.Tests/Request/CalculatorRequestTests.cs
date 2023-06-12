using Calculator.Logic.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Calculator.Domain.Tests.Request
{
    [TestClass]
    public class CalculatorErrorTests
    {
        private Mock<ICalculatorLogic> _calculatorLogicMock;
        private Mock<ICalculatorValidator> _calculatorValidatorMock;
        private Mock<IStringToNumberConvertor> _stringToNumberConvertorMock;
        private CalculatorError _sut;

        [TestInitialize]
        public void Initialize()
        {
            _calculatorLogicMock = new Mock<ICalculatorLogic>();
            _calculatorValidatorMock = new Mock<ICalculatorValidator>();
            _stringToNumberConvertorMock = new Mock<IStringToNumberConvertor>();

            _sut = new CalculatorError();
        }
    }
}
