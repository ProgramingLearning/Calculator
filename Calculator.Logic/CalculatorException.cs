using System;

namespace Calculator.Logic.Errors
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
