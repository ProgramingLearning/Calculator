using Calculator.Domain.Request;
using Calculator.Domain.Response;
using Calculator.Logic.Errors;
using Calculator.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Calculator.Domain.Tests.Request
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
        public void DoSingleTermOperation_WhenTermListIsValidForIsPrime_AndOperationIsIsPrime_AndNumberIsNotPrime_ReturnsCorrectValue()
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

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsNegative_AndOperationIsIsPrime_ThrowsCalculatorException()
        {
            // Arrange
            _sut.AddTerm("-7");
            _sut.SetCurrentOperation(Operation.IsPrime);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(-7);
            _calculatorErrorMock.Setup(x => x.HandleCalculatorException(It.IsAny<CalculatorException>()))
                .Returns(new CalculatorResult { IsSuccess = false, Message = "The number is not a Positive Integer" });

            // Act
            CalculatorResult actual = _sut.DoSingleTermOperation();

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "The number is not a Positive Integer");
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsZero_AndOperationIsIsPrime_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("0");
            _sut.SetCurrentOperation(Operation.IsPrime);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(0);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("0", actual.Value);
            Assert.AreEqual("Is not a Prime number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsPrime), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForIsPalindrome_AndOperationIsIsPalindrome_AndNumberIsNotPalindrome_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("12");
            _sut.SetCurrentOperation(Operation.IsPalindrome);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(12);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("12", actual.Value);
            Assert.AreEqual("Is not a Palindrome number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsPalindrome), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForIsPalindrome_AndOperationIsIsPalindrome_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("11");
            _sut.SetCurrentOperation(Operation.IsPalindrome);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(11);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("11", actual.Value);
            Assert.AreEqual("Is a Palindrome number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsPalindrome), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForIsSuperpalindrome_AndOperationIsIsSuperpalindrome_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("121");
            _sut.SetCurrentOperation(Operation.IsSuperpalindrome);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(121);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("121", actual.Value);
            Assert.AreEqual("Is a SuperPalindrome number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsSuperpalindrome), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForIsSuperpalindrome_AndOperationIsIsSuperpalindrome_AndNumberIsNotSuperpalindrome_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("134");
            _sut.SetCurrentOperation(Operation.IsSuperpalindrome);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(134);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("134", actual.Value);
            Assert.AreEqual("Is not a SuperPalindrome number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsSuperpalindrome), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForIsSuperpalindrome_AndOperationIsIsSuperpalindrome_AndNumberIsPalindromeButIsNotSuperpalindrome_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("9");
            _sut.SetCurrentOperation(Operation.IsSuperpalindrome);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(9);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("9", actual.Value);
            Assert.AreEqual("Is not a SuperPalindrome number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsSuperpalindrome), Times.Once());
        }
        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForIsOddOrEven_AndOperationIsOddOrEven_AndNumberIsOdd_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("121");
            _sut.SetCurrentOperation(Operation.IsOddOrEven);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(121);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("121", actual.Value);
            Assert.AreEqual("Is an Odd number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsOddOrEven), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForIsOddOrEven_AndOperationIsOddOrEven_AndNumberIsEven_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("122");
            _sut.SetCurrentOperation(Operation.IsOddOrEven);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(122);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("122", actual.Value);
            Assert.AreEqual("Is an Even number", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.IsOddOrEven), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForSquareRoot_AndOperationIsSquareRoot_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81");
            _sut.SetCurrentOperation(Operation.SquareRoot);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<double>(It.IsAny<List<string>>()))
                .Returns(81);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("9", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.SquareRoot), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForAbsoluteValue_AndOperationIsAbsoluteValue_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("-81");
            _sut.SetCurrentOperation(Operation.AbsoluteValue);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<double>(It.IsAny<List<string>>()))
                .Returns(-81);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("81", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.AbsoluteValue), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForReverse_AndOperationIsReverse_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81");
            _sut.SetCurrentOperation(Operation.Reverse);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(81);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("18", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.Reverse), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListIsValidForChangeSign_AndOperationChangeSign_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81");
            _sut.SetCurrentOperation(Operation.ChangeSign);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<double>(It.IsAny<List<string>>()))
                .Returns(81);

            //Act
            var actual = _sut.DoSingleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("-81", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.ChangeSign), Times.Once());
        }

        [TestMethod]
        public void DoSingleTermOperation_WhenTermListZero_AndOperationIsChangeSign_ThrowsCalculatorException()
        {
            // Arrange 
            _sut.AddTerm("0");
            _sut.SetCurrentOperation(Operation.ChangeSign);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerm<int>(It.IsAny<List<string>>()))
                .Returns(0);
            _calculatorErrorMock.Setup(x => x.HandleCalculatorException(It.IsAny<CalculatorException>()))
                .Returns(new CalculatorResult { IsSuccess = false, Message = "Zero can´t be negative or positive" });

            // Act
            CalculatorResult actual = _sut.DoSingleTermOperation();

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.AreEqual(actual.Message, "Zero can´t be negative or positive");
        }

        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForSum_AndOperationIsSum_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81, 2");
            _sut.SetCurrentOperation(Operation.Sum);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 81, 2 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("83", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.Sum), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForSubtract_AndOperationIsSubtract_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81, 2");
            _sut.SetCurrentOperation(Operation.Subtract);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 81, 2 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("79", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.Subtract), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForMultiply_AndOperationIsMultiply_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81, 2");
            _sut.SetCurrentOperation(Operation.Multiply);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 81, 2 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("162", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.Multiply), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForDivide_AndOperationIsDivide_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("81, 3");
            _sut.SetCurrentOperation(Operation.Divide);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 81, 3 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("27", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.Divide), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_WhenTermListIsValidForPower_AndOperationIsPower_ReturnsCorrectValue()
        {
            //Arrage
            _sut.AddTerm("2, 3");
            _sut.SetCurrentOperation(Operation.Power);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 2, 3 });


            //Act
            var actual = _sut.DoMultipleTermOperation();

            //Assert
            Assert.IsTrue(actual.IsSuccess);
            Assert.AreEqual("8", actual.Value);
            Assert.AreEqual("Result", actual.Message);
            _calculatorValidatorMock.Verify(x => x.ValidateOperation(Operation.Power), Times.Once());
        }

        [TestMethod]
        public void DoMultipleTermOperation_HandleErrorsWithTryAndCatchAndDoCalculation_CallHandleCalculatorException_WhenCalculatorExceptionThrown()
        {
            //Arrage
            _sut.AddTerm("2, 0");
            _sut.SetCurrentOperation(Operation.Divide);
            _stringToNumberConvertorMock.Setup(x => x.ReadTerms<double>(It.IsAny<List<string>>()))
                .Returns(new List<double> { 2, 0 });
            var calculatorException = new CalculatorException(Error.DivideBy0);
            _calculatorValidatorMock.Setup(x => x.ValidateOperation(It.IsAny<Operation>())).Throws(calculatorException);

            //Act
            var actual = _sut.DoMultipleTermOperation();

            // Assert
            _calculatorErrorMock.Verify(x => x.HandleCalculatorException(calculatorException), Times.Once);
        }

        [TestMethod]
        public void DoMultipleTermOperation_DoCalculation_DefaultCase_ReturnsEmptyCalculatorResult()
        {
            // Arrange
            _sut.AddTerm("5");
            _sut.SetCurrentOperation(Operation.None);

            // Act
            CalculatorResult actual = _sut.DoMultipleTermOperation();

            // Assert
            Assert.IsFalse(actual.IsSuccess);
            Assert.IsNull(actual.Value);
            Assert.IsNull(actual.Message);
        }

        [TestMethod]
        public void GetCurrentOperation_ShouldReturnCurrentOperation()
        {
            _sut.AddTerm("2, 0");
            _sut.SetCurrentOperation(Operation.Sum);

            // Act
            var actual = _sut.GetCurrentOperation();

            // Assert
            Assert.AreEqual(Operation.Sum, actual);
        }

        [TestMethod]
        public void ShouldPerformOperationForCurrentTerms_Should_Return_False_When_NewOperation_Equals_CurrentOperation()
        {
            // Arrange
            _sut.SetCurrentOperation(Operation.Sum);

            // Act
            var actual = _sut.ShouldPerformOperationForCurrentTerms(Operation.Sum);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldPerformOperationForCurrentTerms_Should_Return_False_When_Terms_Count_Is_Less_Than_2()
        {
            // Arrange
            _sut.SetCurrentOperation(Operation.Sum);
            _sut.AddTerm("1");

            // Act
            var actual = _sut.ShouldPerformOperationForCurrentTerms(Operation.Multiply);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldPerformOperationForCurrentTerms_Should_Return_True_When_NewOperation_Does_Not_Equal_CurrentOperation_And_Terms_Count_Is_Greater_Than_1()
        {
            // Arrange
            _sut.SetCurrentOperation(Operation.Sum);
            _sut.AddTerm("1");
            _sut.SetCurrentOperation(Operation.Subtract);
            _sut.AddTerm("2");

            // Act
            var actual = _sut.ShouldPerformOperationForCurrentTerms(Operation.Multiply);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ResetTerms_ShouldResetTermsToEmptyList()
        {
            // Arrange
            _sut.SetCurrentOperation(Operation.Sum);
            _sut.AddTerm("term1");
            _sut.AddTerm("term2");

            // Act
            _sut.ResetTerms();

            // Assert
            List<string> expectedTerms = new List<string>();
            CalculatorState actualCalculatorState = _sut.GetCalculatorState();
            CollectionAssert.AreEqual(expectedTerms, actualCalculatorState.Terms);
        }

        [TestMethod]
        public void SetState_ShouldSetCalculatorState()
        {
            // Arrange
            CalculatorState calculatorState = new CalculatorState { Terms = new List<string> { "term1", "term2" } };

            // Act
            _sut.SetState(calculatorState);

            // Assert
            CalculatorState actualCalculatorState = _sut.GetCalculatorState();
            Assert.AreEqual(calculatorState, actualCalculatorState);
        }
    }
}