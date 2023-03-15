using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Logic
{
    public class CalculatorLogic : ICalculatorLogic
    {
        private ICalculatorError _calculatorError;
        private ICalculatorValidator _calculatorValidator;
        private IStringToNumberConvertor _stringToNumberConverter;
        private List<string> _terms;
        private Operation _currentOperation;
        private string _lastTerm;

        public CalculatorLogic(ICalculatorError calculatorError, ICalculatorValidator calculatorValidator, IStringToNumberConvertor stringToNumberConverter)
        {
            _calculatorError = calculatorError;
            _calculatorValidator = calculatorValidator;
            _stringToNumberConverter = stringToNumberConverter;
            _terms = new List<string>();
        }

        public CalculatorResult DoMultipleTermOperation()
        {
            if (ShouldRepeatLastOperation(_currentOperation))
            {
                AddLastTermUsed();
            }
            return HandleErrorsWithTryAndCatchAndDoCalculation();
        }

        public CalculatorResult DoSingleTermOperation()
        {
            return HandleErrorsWithTryAndCatchAndDoCalculation();
        }

        private CalculatorResult HandleErrorsWithTryAndCatchAndDoCalculation()
        {
            try
            {
                return DoCalculation();
            }
            catch (CalculatorException ex)
            {
                return _calculatorError.HandleCalculatorException(ex);
            }
        }

        private CalculatorResult DoCalculation()
        {
            _lastTerm = _terms.LastOrDefault();
            _calculatorValidator.ValidateOperation(_currentOperation);
            CalculatorResult calculatorResult = null;
            switch (_currentOperation)
            {
                case Operation.Sum:
                    {
                        calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForMultipleTermsOperation, (x, y) => { return x + y; }));
                        break;
                    }
                case Operation.Subtract:
                    {
                         calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForMultipleTermsOperation, (x, y) => { return x - y; }));
                        break;
                    }
                case Operation.Multiply:
                    {
                        calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForMultipleTermsOperation, (x, y) => { return x * y; }));
                        break;
                    }
                case Operation.Divide:
                    {
                         calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForDivision, (x, y) => { return x / y; }));
                        break;
                    }
                case Operation.Power:
                    {
                        calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForMultipleTermsOperation, (x, y) => { return Math.Pow(x, y); }));
                        break;
                    }
                case Operation.IsPrime:
                    {
                        int termToCheck = GetIntTerm();
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
                case Operation.IsOddOrEven:
                    {
                        int termToCheck = GetIntTerm();
                        calculatorResult = IsOddOrEven(termToCheck);
                        break;
                    }
                case Operation.SquareRoot:
                    {
                        double termToCheck = GetDoubleTerm();
                        calculatorResult = GetDefaultCalculatorResult(Math.Sqrt(termToCheck));
                        break;
                    }
                case Operation.AbsoluteValue:
                    {
                        double termToCheck = GetDoubleTerm();
                        calculatorResult = GetDefaultCalculatorResult(Math.Abs(termToCheck));
                        break;
                    }
                case Operation.Reverse:
                    {
                        int termToCheck = GetIntTerm();
                        calculatorResult = GetDefaultCalculatorResult(Reverse(termToCheck));

                        break;
                    }
                case Operation.IsPalindrome:
                    {
                        int termToCheck = GetIntTerm();
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
                case Operation.IsSuperpalindrome:
                    {
                        int termToCheck = GetIntTerm();
                        calculatorResult = IsSuperpalindrome(termToCheck);
                        break;
                    }
                case Operation.ChangeSign:
                    {
                        double termToCheck = GetDoubleTerm();
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

        private static CalculatorResult GetDefaultCalculatorResult(double resultValue)
        {
            return GetCalculatorResult(true, resultValue, "Result");
        }

        private void ValidateTermsForDivision(List<double> termsList)
        {
            _calculatorValidator.ValidateTermsForDivision(termsList);
        }

        private void ValidateTermsForMultipleTermsOperation(List<double> termsList)
        {
            _calculatorValidator.ValidateTermsForMultipleTermsOperation(termsList);
        }

        private List<double> GetDoubleTerms()
        {
            return _stringToNumberConverter.ReadTerms<double>(_terms);
        }

        private int GetIntTerm()
        {
            return _stringToNumberConverter.ReadTerm<int>(_terms);
        }
        private double GetDoubleTerm()
        {
            return _stringToNumberConverter.ReadTerm<double>(_terms);
        }

        private static bool IsEven(int termToCheck)
        {
            return termToCheck % 2 == 0;
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

        private double ValidateAndGetOperationResultForTerms(Action<List<double>> validationMethod, Func<double, double, double> operationMethod)
        {
            var termsList = GetDoubleTerms();
            validationMethod(termsList);
            var resultValue = termsList.First();
            termsList.Skip(1).ToList().ForEach(x => { resultValue = operationMethod(resultValue, x); });
            return resultValue;
        }

        private static bool IsPrime(int valueToCheck)
        {
            if (valueToCheck<0)
            {
            throw new CalculatorException(Error.IsNotAPositiveInteger);
            }
            if (valueToCheck == 1 || valueToCheck == 0)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(valueToCheck); i++)
            {
                if (valueToCheck % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsPalindrome(int valueToCheck)
        {
            int reversed = Reverse(valueToCheck);
            bool isPalindrom;

            if (valueToCheck == reversed)
            {
                isPalindrom = true;
            }
            else
            {
                isPalindrom = false;
            }
            return isPalindrom;
        }

        private static int Reverse(int number)
        {
            int reversedNumber = 0;
            int reminder;

            while (number > 0)
            {
                reminder = number % 10;
                reversedNumber = reversedNumber * 10 + reminder;
                number /= 10;
            }

            return reversedNumber;
        }
        public void SetCurrentOperation(Operation operation)
        {
            _currentOperation = operation;
        }

        public Operation GetCurrentOperation()
        {
            return _currentOperation;
        }

        public bool ShouldPerformOperationForCurrentTerms(Operation newOperation)
        {
            return newOperation != _currentOperation && _terms.Count > 1;
        }

        public bool ShouldRepeatLastOperation(Operation newOperation)
        {
            return newOperation == _currentOperation && _terms.Count == 1;
        }

        public void AddTerm(string term)
        {
            _terms.Add(term);
        }

        public void AddLastTermUsed()
        {
            _terms.Add(_lastTerm);
        }

        public void ResetTerms()
        {
            _terms = new List<string>();
        }
    }
}
