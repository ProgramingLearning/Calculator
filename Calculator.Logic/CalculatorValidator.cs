﻿using Calculator.Domain.Request;
using Calculator.Logic.Errors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Logic
{
    public class CalculatorValidator : ICalculatorValidator
    {
        public void ValidateMultipleTermOperation(MultipleTermOperation operation)
        {
            if (operation == MultipleTermOperation.None)                                
            {
                throw new CalculatorException(Error.None);
            }
        }

        public void ValidateSingleTermOperation(SingleTermOperation operation)
        {
            if (operation == SingleTermOperation.None)
            {
                throw new CalculatorException(Error.None);
            }
        }

        public void ValidateTermsForDivision(List<double> terms)
        {
            ValidateTermsForMultipleTermsOperation(terms);

            if (terms.Skip(1).Any(x => x == 0))
            {
                throw new CalculatorException(Error.DivideBy0);
            }
        }

        public void ValidateTermsForMultipleTermsOperation(List<double> terms)
        {
            if (terms.Count < 2)
            {
                throw new CalculatorException(Error.ToFewTerms);
            }
        }
    }
}
