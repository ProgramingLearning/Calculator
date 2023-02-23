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
                AddLastTermUsed(_lastTerm);
            }
            try
            {
                return DoCalculation();
            }
            catch (CalculatorException ex)
            {
                return _calculatorError.HandleCalculatorException(ex);
            }
        }

        public CalculatorResult DoCalculation()
        {
            _lastTerm = _terms.LastOrDefault();
            _calculatorValidator.ValidateOperation(_currentOperation);
            CalculatorResult calculatorResult = null;
            switch (_currentOperation)
            {
                case Operation.Sum:
                    {
                        List<double> termsList = GetTerms();
                        DoValidationForTwoTermsOperation(termsList);
                        var resultValue = DoSpecificTwoTermsAction(termsList, (x, y) => { return x + y; });
                        calculatorResult = DisplayDefault(resultValue);
                        break;
                    }
                case Operation.Subtract:
                    {
                        List<double> termsList = GetTerms();
                        DoValidationForTwoTermsOperation(termsList);
                        var resultValue = DoSpecificTwoTermsAction(termsList, (x, y) => { return x - y; });
                        calculatorResult = DisplayDefault(resultValue);
                        break;
                    }
                case Operation.Multiply:
                    {
                        List<double> termsList = GetTerms();
                        DoValidationForTwoTermsOperation(termsList);
                        var resultValue = DoSpecificTwoTermsAction(termsList, (x, y) => { return x * y; });
                        calculatorResult = DisplayDefault(resultValue);
                        break;
                    }
                case Operation.Divide:
                    {
                        List<double> termsList = GetTerms();
                        DoValidationForDivision(termsList);
                        var resultValue = DoSpecificTwoTermsAction(termsList, (x, y) => { return x / y; });
                        calculatorResult = DisplayDefault(resultValue);
                        break;
                    }
                case Operation.Power:
                    {
                        List<double> termsList = GetTerms();
                        DoValidationForTwoTermsOperation(termsList);
                        var resultValue = DoSpecificTwoTermsAction(termsList, (x, y) => { return Math.Pow(x, y); });
                        calculatorResult = DisplayDefault(resultValue);
                        break;
                    }
                case Operation.IsPrime:
                    {
                        int termToCheck = GetIntTermToCheck();
                        if (IsPrime(termToCheck))
                        {
                            calculatorResult = CalculatorResult(true, termToCheck, "Is a Prime number");
                        }
                        else
                        {
                            calculatorResult = CalculatorResult(true, termToCheck, "Is not a Prime number");
                        }
                        break;
                    }
                case Operation.IsOddOrEven:
                    {
                        int termToCheck = GetIntTermToCheck();
                        if (IsEven(termToCheck))
                        {
                            calculatorResult = CalculatorResult(true, termToCheck, "Is an Even number");
                        }
                        else
                        {
                            calculatorResult = CalculatorResult(true, termToCheck, "Is an Odd number");
                        }
                        break;
                    }
                case Operation.SquareRoot:
                    {
                        double termToCheck = GetDoubleTermToCheck();
                        calculatorResult = DisplayDefault(Math.Sqrt(termToCheck));
                        break;
                    }
                case Operation.AbsoluteValue:
                    {
                        double termToCheck = GetDoubleTermToCheck();
                        calculatorResult = DisplayDefault(Math.Abs(termToCheck));
                        break;
                    }
                case Operation.Reverse:
                    {
                        int termToCheck = GetIntTermToCheck();
                        calculatorResult = DisplayDefault(Reverse(termToCheck));

                        break;
                    }
                case Operation.Palindrome:
                    {
                        int termToCheck = GetIntTermToCheck();
                        if (IsPalindrome(termToCheck))
                        {
                            calculatorResult = CalculatorResult(true, termToCheck, "Is a Palindrome number");
                        }
                        else
                        {
                            calculatorResult = CalculatorResult(true, termToCheck, "Is not a Palindrome number");
                        }
                        break;
                    }
                case Operation.Superpalindrome:
                    {
                        int termToCheck = GetIntTermToCheck();
                        if (IsPalindrome(termToCheck))
                        {
                            int valueToCheck = RaiseToPowerTwo(termToCheck);
                            if (IsPalindrome(valueToCheck))
                            {
                                calculatorResult = CalculatorResult(true, termToCheck, "Is a SuperPalindrome number");
                            }
                            else
                            {
                                calculatorResult = CalculatorResult(true, termToCheck, "Is not a SuperPalindrome number");
                            }
                        }
                        else
                        {
                            calculatorResult = CalculatorResult(true, termToCheck, "Is not a SuperPalindrome number");
                        }
                        break;
                    }
                case Operation.ChangeSign:
                    {
                        double termToCheck = GetDoubleTermToCheck();
                        calculatorResult = ChangeSign(termToCheck);
                        break;
                    }
                default:
                    calculatorResult = new CalculatorResult();
                    break;
            }

            return calculatorResult;
        }

        private static int RaiseToPowerTwo(int termToCheck)
        {
            return (int)Math.Pow(termToCheck, 2);
        }

        private static CalculatorResult ChangeSign(double termToCheck)
        {
            return DisplayDefault((-1) * (termToCheck));
        }

        private static CalculatorResult DisplayDefault(double resultValue)
        {
            return CalculatorResult(true, resultValue, "Result");
        }

        private void DoValidationForDivision(List<double> termsList)
        {
            _calculatorValidator.ValidateTermsForDivision(termsList);
        }

        private void DoValidationForTwoTermsOperation(List<double> termsList)
        {
            _calculatorValidator.ValidateTwoTermsOperation(termsList);
        }

        private List<double> GetTerms()
        {
            return _stringToNumberConverter.ReadTerms<double>(_terms);
        }

        private int GetIntTermToCheck()
        {
            return _stringToNumberConverter.ReadTerm<int>(_terms);
        }
        private double GetDoubleTermToCheck()
        {
            return _stringToNumberConverter.ReadTerm<double>(_terms);
        }

        private static bool IsEven(int termToCheck)
        {
            return termToCheck % 2 == 0;
        }

        private static CalculatorResult CalculatorResult(bool isSuccess, double resultValue, string message)
        {
            return new CalculatorResult
            {
                IsSuccess = isSuccess,
                Message = message,
                Value = resultValue.ToString()
            };
        }

        private static double DoSpecificTwoTermsAction(List<double> termsList, Func<double, double, double> action)
        {
            var result = termsList.First();
            termsList.Skip(1).ToList().ForEach(x => { result = action(result, x); });
            return result;
        }

        private static bool IsPrime(int valueToCheck)
        {
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

        private static int Reverse(int a)
        {
            int oglindit = 0;
            int reminder;
            int numar = a;

            while (numar > 0)
            {
                reminder = numar % 10;
                oglindit = oglindit * 10 + reminder;
                numar /= 10;
            }

            return oglindit;
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

        public void AddLastTermUsed(string term)
        {
            _terms.Add(_lastTerm);
        }

        public void ResetTerms()
        {
            _terms = new List<string>();
        }
    }
}
