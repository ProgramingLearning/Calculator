using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Logic
{
    public interface ICalculatorError
    {
        CalculatorResult HandleCalculatorException(CalculatorException ex);
    }
}
