using System;
using System.Collections.Generic;
using System.Text;
using Calculator;
using Calculator.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Logic.Tests
{
    [TestClass()]
    public class CalculatorExceptionHandlerTests
    {
     
        [TestMethod()]
        public void HandleCalculatorException_None_ReturnsAllGood()
        {
            var ex = new CalculatorException(CalculatorExceptionCause.None);
            var result = CalculatorExceptionHandler.HandleCalculatorException(ex);

            Assert.AreEqual("all good", result);
        }

        [TestMethod()]
        public void HandleCalculatorException_DivideBy0_ReturnsCannotDivideBy0()
        {
            var ex = new CalculatorException(CalculatorExceptionCause.DivideBy0);
            var result = CalculatorExceptionHandler.HandleCalculatorException(ex);

            Assert.AreEqual("Cannot divide by 0", result);
        }

        [TestMethod()]
        public void HandleCalculatorException_NoOperationSelected_ReturnsSelectOperation()
        {
            var ex = new CalculatorException(CalculatorExceptionCause.NoOperationSelected);
            var result = CalculatorExceptionHandler.HandleCalculatorException(ex);

            Assert.AreEqual("Select operation: +, -, * or /", result);
        }

        [TestMethod()]
        public void HandleCalculatorException_ThisOperationNeedsTwoOperants_ReturnsNeedsTwoOperants()
        {
            var ex = new CalculatorException(CalculatorExceptionCause.ThisOperationNeedsTwoOperants);
            var result = CalculatorExceptionHandler.HandleCalculatorException(ex);

            Assert.AreEqual("This operation needs two operants.", result);
        }

        [TestMethod()]
        public void HandleCalculatorException_ThisOperationRequiersNaturalOperants_ReturnsRequiresNaturalOperants()
        {
            var ex = new CalculatorException(CalculatorExceptionCause.ThisOperationRequiersNaturalOperants);
            var result = CalculatorExceptionHandler.HandleCalculatorException(ex);

            Assert.AreEqual("This operation requiers natural operants.", result);
        }

        [TestMethod()]
        public void HandleCalculatorException_InvalidNumberInput_ReturnsInvalidNumberInput()
        {
            var ex = new CalculatorException(CalculatorExceptionCause.InvalidNumberInput, "not a number");
            var result = CalculatorExceptionHandler.HandleCalculatorException(ex);

            Assert.AreEqual("not a number is not a number. Please enter a number", result);
        }

        [TestMethod()]
        public void HandleCalculatorException_Default_ReturnsUnknownCause()
        {
            var ex = new CalculatorException((CalculatorExceptionCause)999);
            var result = CalculatorExceptionHandler.HandleCalculatorException(ex);

            Assert.AreEqual("unknown cause", result);
        }
    }
}

