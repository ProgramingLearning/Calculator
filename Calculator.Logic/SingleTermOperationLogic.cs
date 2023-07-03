using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Domain.Response;
using Calculator.Domain.Request;
using Calculator.Logic.Errors;

namespace Calculator.Logic
{
    public class SingleTermOperationLogic : ISingleTermOperationLogic
    {
        private ICalculatorError _calculatorError;
        private ICalculatorValidator _calculatorValidator;
        private IStringToNumberConvertor _stringToNumberConverter;

        public SingleTermOperationLogic(ICalculatorError calculatorError, ICalculatorValidator calculatorValidator, IStringToNumberConvertor stringToNumberConverter)
        {
            _calculatorError = calculatorError;
            _calculatorValidator = calculatorValidator;
            _stringToNumberConverter = stringToNumberConverter;
        }

        public CalculatorResult DoSingleTermOperation(SingleTermOperation operation, string term)
        {
            return HandleErrorsWithTryAndCatchAndDoCalculation(operation, term);
        }

        private CalculatorResult HandleErrorsWithTryAndCatchAndDoCalculation(SingleTermOperation operation, string term)
        {
            try
            {
                return DoCalculation(operation, term);
            }
            catch (CalculatorException ex)
            {
                return _calculatorError.HandleCalculatorException(ex);
            }
        }

        private CalculatorResult DoCalculation(SingleTermOperation operation, string term)
        {
            _calculatorValidator.ValidateSingleTermOperation(operation);
            CalculatorResult calculatorResult = null;
            switch (operation)
            {
                case SingleTermOperation.IsPrime:
                    {
                        int termToCheck = GetIntTerm(term);
                        if (IsPrime(termToCheck))
                        {
                            calculatorResult = GetCalculatorResult(true, termToCheck, "Is a Prime number");
                        }
                        else
                        {
                            calculatorResult = GetCalculatorResult(true, termToCheck, "Is not a Prime number");
                        }
                        break;
                    }
                case SingleTermOperation.IsOddOrEven:
                    {
                        int termToCheck = GetIntTerm(term);
                        calculatorResult = IsOddOrEven(termToCheck);
                        break;
                    }
                case SingleTermOperation.SquareRoot:
                    {
                        double termToCheck = GetDoubleTerm(term);
                        calculatorResult = GetDefaultCalculatorResult(Math.Sqrt(termToCheck));
                        break;
                    }
                case SingleTermOperation.AbsoluteValue:
                    {
                        double termToCheck = GetDoubleTerm(term);
                        calculatorResult = GetDefaultCalculatorResult(Math.Abs(termToCheck));
                        break;
                    }
                case SingleTermOperation.Reverse:
                    {
                        int termToCheck = GetIntTerm(term);
                        calculatorResult = GetDefaultCalculatorResult(Reverse(termToCheck));

                        break;
                    }
                case SingleTermOperation.IsPalindrome:
                    {
                        int termToCheck = GetIntTerm(term);
                        if (IsPalindrome(termToCheck))
                        {
                            calculatorResult = GetCalculatorResult(true, termToCheck, "Is a Palindrome number");
                        }
                        else
                        {
                            calculatorResult = GetCalculatorResult(true, termToCheck, "Is not a Palindrome number");
                        }
                        break;
                    }
                case SingleTermOperation.IsSuperpalindrome:
                    {
                        int termToCheck = GetIntTerm(term);
                        calculatorResult = IsSuperpalindrome(termToCheck);
                        break;
                    }
                case SingleTermOperation.ChangeSign:
                    {
                        double termToCheck = GetDoubleTerm(term);
                        calculatorResult = GetDefaultCalculatorResultWithOpositeSign(termToCheck);
                        break;
                    }
                default:
                    calculatorResult = new CalculatorResult();
                    break;
            }

            return calculatorResult;
        }

        private static CalculatorResult IsOddOrEven(int termToCheck)
        {
            CalculatorResult calculatorResult;
            if (IsEven(termToCheck))
            {
                calculatorResult = GetCalculatorResult(true, termToCheck, "Is an Even number");
            }
            else
            {
                calculatorResult = GetCalculatorResult(true, termToCheck, "Is an Odd number");
            }

            return calculatorResult;
        }

        private static CalculatorResult IsSuperpalindrome(int termToCheck)
        {
            CalculatorResult calculatorResult;
            if (IsPalindrome(termToCheck))
            {
                int valueToCheck = RaiseToPowerTwo(termToCheck);
                if (IsPalindrome(valueToCheck))
                {
                    calculatorResult = GetCalculatorResult(true, termToCheck, "Is a SuperPalindrome number");
                }
                else
                {
                    calculatorResult = GetCalculatorResult(true, termToCheck, "Is not a SuperPalindrome number");
                }
            }
            else
            {
                calculatorResult = GetCalculatorResult(true, termToCheck, "Is not a SuperPalindrome number");
            }

            return calculatorResult;
        }

        private static int RaiseToPowerTwo(int termToCheck)
        {
            return (int)Math.Pow(termToCheck, 2);
        }

        private static CalculatorResult GetDefaultCalculatorResultWithOpositeSign(double termToCheck)
        {
            if (termToCheck == 0)
            {
                throw new CalculatorException(Error.ZeroCantBeNegativeOrPositive);
            }
            return GetDefaultCalculatorResult((-1) * (termToCheck));
        }

        private int GetIntTerm(string term)
        {
            return _stringToNumberConverter.ReadTerm<int>(term);
        }

        private double GetDoubleTerm(string term)
        {
            return _stringToNumberConverter.ReadTerm<double>(term);
        }

        private static CalculatorResult GetDefaultCalculatorResult(double resultValue)
        {
            return GetCalculatorResult(true, resultValue, "Result");
        }

        private static CalculatorResult GetCalculatorResult(bool isSuccess, double resultValue, string message)
        {
            return new CalculatorResult
            {
                IsSuccess = isSuccess,
                Message = message,
                Value = resultValue.ToString()
            };
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        private static bool IsPalindrome(int number)
        {
            int reverse = 0;
            int original = number;
            while (number > 0)
            {
                reverse = reverse * 10 + number % 10;
                number /= 10;
            }

            return original == reverse;
        }

        private static int Reverse(int number)
        {
            int reverse = 0;
            while (number != 0)
            {
                reverse = reverse * 10 + number % 10;
                number = number / 10;
            }
            return reverse;
        }
    }
}

