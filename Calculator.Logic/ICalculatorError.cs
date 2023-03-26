using Calculator.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Logic.Errors
{
    public interface ICalculatorError
    {
        CalculatorResult HandleCalculatorException(CalculatorException ex);
    }
}
