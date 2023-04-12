using System;

namespace Calculator
{
    public class CalculatorException : Exception
    {
        public string Value { get; set; }
        public CalculatorExceptionCause ErrorType { get; set; }

        public CalculatorException(CalculatorExceptionCause errorType)
        {
            this.ErrorType = errorType;
        }

        public CalculatorException(CalculatorExceptionCause errorType, string value)
        {
            this.ErrorType = errorType;
            this.Value = value;
        }
    }
}
