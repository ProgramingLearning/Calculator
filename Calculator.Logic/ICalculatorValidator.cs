using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Logic
{
    public interface ICalculatorValidator
    {
        void ValidateTermsForDivision(List<double> terms);
        void ValidateTwoTermsOperation(List<double> terms);
        void ValidateOperation(Operation operation);
    }
}
