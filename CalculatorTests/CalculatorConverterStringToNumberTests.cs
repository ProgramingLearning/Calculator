using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Tests
{
    [TestClass()]
    public class CalculatorConverterStringToNumberTests
    {
        [TestMethod()]
        public void ConvertToUIntTest()
        {
            var result = CalculatorConverterStringToNumber.ConvertToUInt("1.3");
            Assert.IsInstanceOfType(result, typeof(uint));
            Assert.Equals(1, result);
        }
    }
}