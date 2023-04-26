using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Logic
{
    public  class CalculatorExceptionHandler
    {
        public  string HandleCalculatorException(CalculatorException ex)
        {
            switch (ex.ErrorType)
            {
                case CalculatorExceptionCause.None:
                    {
                        return "all good";
                    }
                case CalculatorExceptionCause.DivideBy0:
                    {
                        return "Cannot divide by 0";
                    }
                case CalculatorExceptionCause.NoOperationSelected:
                    {
                        return "Select operation: +, -, * or /";
                    }
                case CalculatorExceptionCause.ThisOperationNeedsTwoOperants:
                    {
                        return "This operation needs two operants.";
                    }
                case CalculatorExceptionCause.ThisOperationRequiersNaturalOperants:
                    {
                        return "This operation requiers natural operants.";
                    }
                case CalculatorExceptionCause.InvalidNumberInput:
                    {
                        return $"{ex.Value} is not a number. Please enter a number";
                    }
                default:
                    {
                        return "unknown cause";
                    }
            }
        }
    }
}
