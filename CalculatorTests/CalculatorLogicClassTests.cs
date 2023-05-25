using System;
using System.Collections.Generic;
using System.Text;
using Calculator;
using Calculator.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Logic.UnitTests
{
    [TestClass()]
    public class CalculatorLogicClassTests
    {
        [TestMethod()]
        public void ExecuteSumOperation_WithValidTerms_ReturnsCorrectResult()
        {
            string firstTerm = "2";
            string secondTerm = "3";
            double expectedValue = 5;

            CalculatorResult result = CalculatorLogic.ExecuteSumOperation(firstTerm, secondTerm);
            Assert.AreEqual(expectedValue.ToString(), result.Value);
        }

        [TestMethod]
        public void ExecuteSumOperation_WithInvalidTerms_ThrowsException()
        {
            string firstTerm = "abc";
            string secondTerm = "3";

            Assert.ThrowsException<FormatException>(() => CalculatorLogic.ExecuteSumOperation(firstTerm, secondTerm));
        }

        [TestMethod]
        public void ExecuteSubtractOperation_WithValidTerms_ReturnsCorrectResult()
        {
            string firstTerm = "5";
            string secondTerm = "3";
            double expectedValue = 2;

            CalculatorResult result = CalculatorLogic.ExecuteSubtractOperation(firstTerm, secondTerm);
            Assert.AreEqual(expectedValue.ToString(), result.Value);
        }

        [TestMethod]
        public void ExecuteSubtractOperation_WithInvalidTerms_ThrowsException()
        {
            string firstTerm = "abc";
            string secondTerm = "3";

            Assert.ThrowsException<FormatException>(() => CalculatorLogic.ExecuteSubtractOperation(firstTerm, secondTerm));
        }

        [TestMethod]
        public void ExecuteMultiplyOperation_WithValidTerms_ReturnsCorrectResult()
        {
            string firstTerm = "4";
            string secondTerm = "5";
            double expectedValue = 20;

            CalculatorResult result = CalculatorLogic.ExecuteMultiplyOperation(firstTerm, secondTerm);
            Assert.AreEqual(expectedValue.ToString(), result.Value);
        }

        [TestMethod]
        public void ExecuteMultiplyOperation_WithInvalidTerms_ThrowsException()
        {
            string firstTerm = "abc";
            string secondTerm = "5";

            Assert.ThrowsException<FormatException>(() => CalculatorLogic.ExecuteMultiplyOperation(firstTerm, secondTerm));
        }
        public void ExecuteDivideOperation_WithValidTerms_ReturnsCorrectResult()
        {
            string firstTerm = "10";
            string secondTerm = "2";
            double expectedValue = 5;

            CalculatorResult result = CalculatorLogic.ExecuteDivideOperation(firstTerm, secondTerm);
            Assert.AreEqual(expectedValue.ToString(), result.Value);
        }

        [TestMethod]
        public void ExecuteDivideOperation_DivideByZero_ThrowsException()
        {
            string firstTerm = "10";
            string secondTerm = "0";

            Assert.ThrowsException<DivideByZeroException>(() => CalculatorLogic.ExecuteDivideOperation(firstTerm, secondTerm));
        }

        [TestMethod]
        public void ExecuteDivideOperation_WithInvalidTerms_ThrowsException()
        {
            string firstTerm = "abc";
            string secondTerm = "2";

            Assert.ThrowsException<FormatException>(() => CalculatorLogic.ExecuteDivideOperation(firstTerm, secondTerm));
        }
        [TestMethod]
        public void ExecuteRaiseNumberToPower_WithValidTerms_ReturnsCorrectResult()
        {
            string firstTerm = "2";
            string secondTerm = "3";
            double expectedValue = 8;

            CalculatorResult result = CalculatorLogic.ExecuteRaiseNumberToPower(firstTerm, secondTerm);
            Assert.AreEqual(expectedValue.ToString(), result.Value);
        }

        [TestMethod]
        public void ExecuteRaiseNumberToPower_WithInvalidTerms_ThrowsException()
        {
            string firstTerm = "abc";
            string secondTerm = "3";

            Assert.ThrowsException<FormatException>(() => CalculatorLogic.ExecuteRaiseNumberToPower(firstTerm, secondTerm));
        }
        [TestMethod]
        public void ExecuteSquareRootOperation_WithValidTerm_ReturnsCorrectResult()
        {
            string term = "25";
            double expectedValue = 5;

            CalculatorResult result = CalculatorLogic.ExecuteSquareRootOperation(term);
            Assert.AreEqual(expectedValue.ToString(), result.Value);
        }

        [TestMethod]
        public void ExecuteSquareRootOperation_WithInvalidTerm_ThrowsException()
        {
            string term = "abc";

            Assert.ThrowsException<FormatException>(() => CalculatorLogic.ExecuteSquareRootOperation(term));
        }
        [TestMethod]
        public void ExecuteNumberParityOperation_WithEvenNumber_ReturnsEvenResult()
        {
            string term = "4";
            string expectedMessage = "The number is even.";
            string expectedValue = "4";

            CalculatorResult result = CalculatorLogic.ExecuteNumberParityOperation(term);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void ExecuteNumberParityOperation_WithOddNumber_ReturnsOddResult()
        {
            string term = "7";
            string expectedMessage = "The number is odd.";
            string expectedValue = "7";

            CalculatorResult result = CalculatorLogic.ExecuteNumberParityOperation(term);

            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void ExecuteNumberParityOperation_WithInvalidTerm_ThrowsException()
        {
            string term = "abc";

            Assert.ThrowsException<FormatException>(() => CalculatorLogic.ExecuteNumberParityOperation(term));
        }
        [TestMethod]
        public void ExecuteGetMirroredOperation_WithNaturalNumber_ReturnsMirroredResult()
        {
            string term = "12345";
            string expectedValue = "54321";

            CalculatorResult result = CalculatorLogic.ExecuteGetMirroredOperation(term);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void ExecuteGetMirroredOperation_WithNonNaturalNumber_ReturnsErrorMessage()
        {
            string term = "12.34";
            string expectedMessage = "Please enter a natural number.";

            CalculatorResult result = CalculatorLogic.ExecuteGetMirroredOperation(term);
            Assert.AreEqual(expectedMessage, result.Message);
        }
        [TestMethod]
        public void ExecutePrimeOperation_WithPrimeNumber_ReturnsPrimeResult()
        {
            string term = "7";
            string expectedMessage = "7 is a prime number.";
            string expectedValue = "7";

            CalculatorResult result = CalculatorLogic.ExecutePrimeOperation(term);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void ExecutePrimeOperation_WithNonPrimeNumber_ReturnsNonPrimeResult()
        {
            string term = "10";
            string expectedMessage = "10 is not a prime number.";
            string expectedValue = "10";

            CalculatorResult result = CalculatorLogic.ExecutePrimeOperation(term);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void ExecutePrimeOperation_WithNonNaturalNumber_ReturnsErrorMessage()
        {
            string term = "5.5";
            string expectedMessage = "5.5 is not a natural number.";
            string expectedValue = "5.5";

            CalculatorResult result = CalculatorLogic.ExecutePrimeOperation(term);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }
        [TestMethod]
        public void ExecutePalindromeOrSuperPalindromeOperation_WithPalindrome_ReturnsPalindromeResult()
        {
            string term = "121";
            string expectedMessage = "121 is a palindrome.";
            string expectedValue = "121";

            CalculatorResult result = CalculatorLogic.ExecutePalindromeOrSuperPalindromeOperation(term);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void ExecutePalindromeOrSuperPalindromeOperation_WithSuperPalindrome_ReturnsSuperPalindromeResult()
        {
            string term = "12321";
            string expectedMessage = "12321 is a superpalindrome.";
            string expectedValue = "12321";
            
            CalculatorResult result = CalculatorLogic.ExecutePalindromeOrSuperPalindromeOperation(term);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void ExecutePalindromeOrSuperPalindromeOperation_WithNonPalindrome_ReturnsNonPalindromeResult()
        {
            string term = "123";
            string expectedMessage = "123 is not a palindrome.";
            string expectedValue = "123";

            CalculatorResult result = CalculatorLogic.ExecutePalindromeOrSuperPalindromeOperation(term);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }
        [TestMethod]
        public void ExecuteLeastCommonMultiple_WithPositiveNumbers_ReturnsLCMResult()
        {
            string firstTerm = "12";
            string secondTerm = "18";
            string expectedMessage = "LCM between 12 and 18 is 36.";
            string expectedValue = "36";

            CalculatorResult result = CalculatorLogic.ExecuteLeastCommonMultiple(firstTerm, secondTerm);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void ExecuteLeastCommonMultiple_WithZeroSecondTerm_ReturnsZeroResult()
        {
            string firstTerm = "10";
            string secondTerm = "0";
            string expectedMessage = "LCM between 10 and 0 is 0.";
            string expectedValue = "0";

            CalculatorResult result = CalculatorLogic.ExecuteLeastCommonMultiple(firstTerm, secondTerm);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }
        [TestMethod]
        public void ExecuteBiggestCommunalDivisor_WithPositiveNumbers_ReturnsBCDResult()
        {
            string firstTerm = "24";
            string secondTerm = "36";
            string expectedMessage = "BCD between 24 and 36 is 12.";
            string expectedValue = "12";

            CalculatorResult result = CalculatorLogic.ExecuteBiggestCommunalDivisor(firstTerm, secondTerm);

            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }

        [TestMethod]
        public void ExecuteBiggestCommunalDivisor_WithZeroFirstTerm_ReturnsSecondTermResult()
        {
            string firstTerm = "0";
            string secondTerm = "48";
            string expectedMessage = "BCD between 0 and 48 is 48.";
            string expectedValue = "48";

            CalculatorResult result = CalculatorLogic.ExecuteBiggestCommunalDivisor(firstTerm, secondTerm);

            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(expectedValue, result.Value);
        }

    }
}

