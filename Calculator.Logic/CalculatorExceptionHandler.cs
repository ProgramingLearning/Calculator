using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Calculator;

namespace Calculator.Logic
{
    public static class CalculatorExceptionHandler
    {
        public static string HandleCalculatorException(CalculatorException ex)
        {
            Dictionary<CalculatorExceptionCause, string> errorMessages = new Dictionary<CalculatorExceptionCause, string>()
{
    { CalculatorExceptionCause.None, "all good" },
    { CalculatorExceptionCause.DivideBy0, "Cannot divide by 0" },
    { CalculatorExceptionCause.NoOperationSelected, "Select operation: +, -, * or /" },
    { CalculatorExceptionCause.ThisOperationNeedsTwoOperants, "This operation needs two operants." },
    { CalculatorExceptionCause.ThisOperationRequiersNaturalOperants, "This operation requiers natural operants." },
    { CalculatorExceptionCause.InvalidNumberInput, "{0} is not a number. Please enter a number" }
};
            string errorMessage;
            if (errorMessages.TryGetValue(ex.ErrorType, out errorMessage))
            {
                if (ex.ErrorType == CalculatorExceptionCause.InvalidNumberInput)
                {
                    errorMessage = string.Format(errorMessage, ex.Value);
                }

                return errorMessage;
            }
            else
            {
                return "unknown cause";
            }
        }
    }
}
