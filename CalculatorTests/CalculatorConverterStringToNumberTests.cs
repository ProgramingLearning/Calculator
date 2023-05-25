using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using Calculator.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Logic.UnitTests
{
    [TestClass()]
    public class CalculatorConvertorStringToNumberTests
    {
        [TestMethod()]
        public void ConvertToDouble_InvalidInput_ExpectException()
        {
            var ex =  Assert.ThrowsException<CalculatorException>(() => CalculatorConverterStringToNumber.ConvertToDouble("blabla"));
            Assert.AreEqual(CalculatorExceptionCause.InvalidNumberInput, ex.ErrorType);

        }
        [TestMethod()]
        public void ConvertToDoubleTest()
        {
            var result = CalculatorConverterStringToNumber.ConvertToDouble("30.33");
            Assert.AreEqual(30.33, result);
        }
        [TestMethod()]
        public void ConvertToUIntTest_InvalidInput_expectException()
        {
            var ex =  Assert.ThrowsException<CalculatorException>(() => CalculatorConverterStringToNumber.ConvertToUInt("-1"));
            Assert.AreEqual(CalculatorExceptionCause.ThisOperationRequiersNaturalOperants, ex.ErrorType);
        }

        [TestMethod()]
        public void ConvertToUIntTest()
        {
            var result = CalculatorConverterStringToNumber.ConvertToUInt("1");
            Assert.AreEqual((uint)1, result);
        }
    }
}