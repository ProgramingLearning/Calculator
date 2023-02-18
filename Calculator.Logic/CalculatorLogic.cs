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
            _terms= new List<string>();
        }

        private double SubstractionAction(double term, double result)
        {
            return result - term;
        }

        private double MultiplyAction(double term, double result)
        {
            return result * term;
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

        public CalculatorResult DoSingleTermOperation()
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
                        var termsList = _stringToNumberConverter.ReadTerms<double>(_terms);

                        if (termsList.Count < 2)
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = false,
                                Message = "To few _terms"
                            };
                        }
                        else
                        {
                            var resultValue = DoSpecificAction(termsList, (x, y) => { return x + y; });

                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Message = "Result",
                                Value = resultValue.ToString()
                            };
                        }
                        break;
                    }
                case Operation.Subtract:
                    {
                        var termsList = _stringToNumberConverter.ReadTerms<double>(_terms);

                        if (termsList.Count < 2)
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = false,
                                Message = "To few _terms"
                            };
                        }
                        else
                        {
                            var resultValue = DoSpecificAction(termsList, SubstractionAction);

                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Message = "Result",
                                Value = resultValue.ToString()
                            };
                        }
                        break;
                    }
                case Operation.Multiply:
                    {
                        var termsList = _stringToNumberConverter.ReadTerms<double>(_terms);
                        if (termsList.Count < 2)
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = false,
                                Message = "To few _terms"
                            };
                        }
                        else
                        {
                            var resultValue = DoSpecificAction(termsList, MultiplyAction);
                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Message = "Result",
                                Value = resultValue.ToString()
                            };
                        }
                        break;
                    }
                case Operation.Divide:
                    {
                        var termsList = _stringToNumberConverter.ReadTerms<double>(_terms);
                        _calculatorValidator.ValidateTermsForDivision(termsList);
                        var resultValue = termsList.First();
                        foreach (var item in termsList.Skip(1))
                        {
                            resultValue /= item;
                        }
                        calculatorResult = new CalculatorResult
                        {
                            IsSuccess = true,
                            Message = "Result",
                            Value = resultValue.ToString()
                        };
                        break;
                    }
                case Operation.Power:
                    {
                        {
                            var termsList = _stringToNumberConverter.ReadTerms<double>(_terms);
                            if (termsList.Count < 2)
                            {
                                calculatorResult = new CalculatorResult
                                {
                                    IsSuccess = false,
                                    Message = "To few _terms"
                                };
                            }
                            else
                            {
                                var resultValue = termsList.First();
                                foreach (var item in termsList.Skip(1))
                                {
                                    resultValue = Math.Pow(resultValue, item);
                                }
                                calculatorResult = new CalculatorResult
                                {
                                    IsSuccess = true,
                                    Message = "Result",
                                    Value = resultValue.ToString()
                                };
                            }
                        }
                        break;
                    }
                case Operation.IsPrime:
                    {
                        if (IsPrime((_stringToNumberConverter.ReadTerm<int>(_terms))))
                        {
                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (_stringToNumberConverter.ReadTerm<int>(_terms)).ToString(),
                                Message = "Is a Prime number",
                            };
                        }
                        else
                        {
                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (_stringToNumberConverter.ReadTerm<int>(_terms)).ToString(),
                                Message = "Is not a Prime number",
                            };
                        }
                        break;
                    }
                case Operation.IsOddOrEven:
                    {
                        if (_stringToNumberConverter.ReadTerm<int>(_terms) % 2 == 0)
                        {
                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (_stringToNumberConverter.ReadTerm<int>(_terms)).ToString(),
                                Message = "Is an Even number",
                            };
                        }
                        else
                        {
                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (_stringToNumberConverter.ReadTerm<int>(_terms)).ToString(),
                                Message = "Is an Odd number",
                            };
                        }
                        break;
                    }
                case Operation.SquareRoot:
                    {
                        calculatorResult = new CalculatorResult
                        {
                            IsSuccess = true,
                            Value = Math.Sqrt(_stringToNumberConverter.ReadTerm<double>(_terms)).ToString(),
                            Message = "Result"
                        };
                        break;
                    }
                case Operation.AbsoluteValue:
                    {
                        calculatorResult = new CalculatorResult
                        {
                            IsSuccess = true,
                            Value = Math.Abs(_stringToNumberConverter.ReadTerm<double>(_terms)).ToString(),
                            Message = "Result"
                        };
                        break;
                    }
                case Operation.Reverse:
                    {
                        calculatorResult = new CalculatorResult
                        {
                            IsSuccess = true,
                            Value = (Reverse(_stringToNumberConverter.ReadTerm<int>(_terms))).ToString(),
                            Message = "Result"
                        };
                        break;
                    }
                case Operation.Palindrome:
                    {
                        if (IsPalindrome((_stringToNumberConverter.ReadTerm<int>(_terms))))
                        {
                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (_stringToNumberConverter.ReadTerm<int>(_terms)).ToString(),
                                Message = "Is a Palindrome number",
                            };
                        }
                        else
                        {
                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (_stringToNumberConverter.ReadTerm<int>(_terms)).ToString(),
                                Message = "Is not a Palindrome number",
                            };
                        }
                        break;
                    }
                case Operation.Superpalindrome:
                    {
                        var valueToCheck = _stringToNumberConverter.ReadTerm<int>(_terms);
                        if (IsPalindrome(valueToCheck))
                        {
                            valueToCheck = (int)Math.Pow(valueToCheck, 2);
                            if (IsPalindrome(_stringToNumberConverter.ReadTerm<int>(_terms)))
                            {
                                calculatorResult = new CalculatorResult
                                {
                                    IsSuccess = true,
                                    Value = (_stringToNumberConverter.ReadTerm<int>(_terms)).ToString(),
                                    Message = "Is a SuperPalindrome number",
                                };
                            }
                            else
                            {
                                calculatorResult = new CalculatorResult
                                {
                                    IsSuccess = true,
                                    Value = (_stringToNumberConverter.ReadTerm<int>(_terms)).ToString(),
                                    Message = "Is not a SuperPalindrome number",
                                };
                            }
                        }
                        else
                        {
                            calculatorResult = new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (_stringToNumberConverter.ReadTerm<int>(_terms)).ToString(),
                                Message = "Is not a SuperPalindrome number",
                            };
                        }
                        break;
                    }
                case Operation.ChangeSign:
                    {
                        calculatorResult = new CalculatorResult
                        {
                            IsSuccess = true,
                            Value = ((-1) * _stringToNumberConverter.ReadTerm<double>(_terms)).ToString(),
                            Message = "Result"
                        };
                        break;
                    }
                default:
                    calculatorResult = new CalculatorResult();
                    break;
            }

            return calculatorResult;
        }

        private static double DoSpecificAction(List<double> termsList, Func<double, double, double> action)
        {
            var result = termsList.First();
            termsList.Skip(1).ToList().ForEach(x => { result = action(x, result); });
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

    }
}
