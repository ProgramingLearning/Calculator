using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public enum CalculatorExceptionCause
    {
        None = 0,
        DivideBy0 = 1,
        NoOperationSelected = 2,
        ThisOperationNeedsTwoOperants = 3,
        ThisOperationRequiersNaturalOperants = 4,
        InvalidNumberInput = 5,
    }
}
