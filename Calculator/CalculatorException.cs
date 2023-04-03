using System;

namespace Calculator
{
    public class CalculatorException : Exception
    {
        public CalculatorExceptionCause ErrorType { get; set; }

        public CalculatorException(CalculatorExceptionCause errorType)
        {
            this.ErrorType = errorType;
        }
    }
}
