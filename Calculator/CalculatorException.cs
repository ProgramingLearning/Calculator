using System;

namespace Calculator
{
    public class CalculatorException : Exception
    {
        public Error ErrorType { get; set; }

        public CalculatorException(Error errorType)
        {
            this.ErrorType = errorType;
        }
    }
}
