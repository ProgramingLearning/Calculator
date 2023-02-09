using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Logic
{
    public class CalculatorLogic : ICalculatorLogic
    {

        public CalculatorResult DoStuff(Operation operation, params string[] terms)

        {
            switch (operation)
            {
                case Operation.None:
                    break;
                case Operation.Sum:
                    {
                        var termsList = ReadTerms<double>(terms);

                        if (termsList.Count < 2)
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = false,
                                Message = "To few terms"
                            };
                        }

                        else
                        {
                            var resultValue = termsList.First();
                            foreach (var item in termsList.Skip(1))
                            {
                                resultValue += item;
                            }
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Message = "Result",
                                Value = resultValue.ToString()
                            };
                        }
                    }


                case Operation.Subtract:
                    {
                        var termsList = ReadTerms<double>(terms);

                        if (termsList.Count < 2)
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = false,
                                Message = "To few terms"
                            };
                        }

                        else
                        {
                            var resultValue = termsList.First();
                            foreach (var item in termsList.Skip(1))
                            {
                                resultValue -= item;
                            }
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Message = "Result",
                                Value = resultValue.ToString()
                            };
                        }
                    }

                case Operation.Multiply:
                    {
                        var termsList = ReadTerms<double>(terms);
                        if (termsList.Count < 2)
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = false,
                                Message = "To few terms"
                            };
                        }

                        else
                        {
                            var resultValue = termsList.First();
                            foreach (var item in termsList.Skip(1))
                            {
                                resultValue *= item;
                            }
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Message = "Result",
                                Value = resultValue.ToString()
                            };
                        }
                    }
                case Operation.Divide:
                    {
                        var termsList = ReadTerms<double>(terms);
                        if (termsList.Count < 2)
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = false,
                                Message = "To few terms"
                            };
                        }
                        if (termsList.Skip(1).Any(x => x == 0))
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = false,
                                Message = "Can not divide by 0"
                            };
                        }
                        else
                        {
                            var resultValue = termsList.First();
                            foreach (var item in termsList.Skip(1))
                            {
                                resultValue /= item;
                            }
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Message = "Result",
                                Value = resultValue.ToString()
                            };
                        }
                    }

                case Operation.IsPrime:
                    {
                        if (IsPrime((ReadTerm<int>(terms))))
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (ReadTerm<int>(terms)).ToString(),
                                Message = "Is a Prime number",
                            };
                        }
                        else
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (ReadTerm<int>(terms)).ToString(),
                                Message = "Is not a Prime number",
                            };
                        }
                    }

                case Operation.IsOddOrEven:
                    {
                        if (ReadTerm<int>(terms) % 2 == 0)
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (ReadTerm<int>(terms)).ToString(),
                                Message = "Is an Even number",
                            };
                        }
                        else
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (ReadTerm<int>(terms)).ToString(),
                                Message = "Is an Odd number",
                            };
                        }
                    }
                case Operation.Power:
                    {
                        {
                            var termsList = ReadTerms<double>(terms);

                            if (termsList.Count < 2)
                            {
                                return new CalculatorResult
                                {
                                    IsSuccess = false,
                                    Message = "To few terms"
                                };
                            }

                            else
                            {
                                var resultValue = termsList.First();
                                foreach (var item in termsList.Skip(1))
                                {
                                    resultValue = Math.Pow(resultValue, item);
                                }
                                return new CalculatorResult
                                {
                                    IsSuccess = true,
                                    Message = "Result",
                                    Value = resultValue.ToString()
                                };
                            }
                        }
                    }
                case Operation.SquareRoot:
                    {
                        return new CalculatorResult
                        {
                            IsSuccess = true,
                            Value = Math.Sqrt(ReadTerm<double>(terms)).ToString(),
                            Message = "Result"
                        };
                    }
                case Operation.AbsoluteValue:
                    {
                        return new CalculatorResult
                        {
                            IsSuccess = true,
                            Value = Math.Abs(ReadTerm<double>(terms)).ToString(),
                            Message = "Result"
                        };
                    }
                case Operation.Reverse:
                    {
                        return new CalculatorResult
                        {
                            IsSuccess = true,
                            Value = (Reverse(ReadTerm<int>(terms))).ToString(),
                            Message = "Result"
                        };
                    }
                case Operation.Palindrome:
                    {
                        if (IsPalindrome((ReadTerm<int>(terms))))
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (ReadTerm<int>(terms)).ToString(),
                                Message = "Is a Palindrome number",
                            };
                        }
                        else
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (ReadTerm<int>(terms)).ToString(),
                                Message = "Is not a Palindrome number",
                            };
                        }
                    }
                case Operation.Superpalindrome:
                    {
                        if (IsPalindrome((ReadTerm<int>(terms))))
                        {
                            if (IsPalindrome((ReadTerm<int>(terms))))
                            {
                                return new CalculatorResult
                                {
                                    IsSuccess = true,
                                    Value = (ReadTerm<int>(terms)).ToString(),
                                    Message = "Is a SuperPalindrome number",
                                };
                            }
                            else
                            {
                                return new CalculatorResult
                                {
                                    IsSuccess = true,
                                    Value = (ReadTerm<int>(terms)).ToString(),
                                    Message = "Is not a SuperPalindrome number",
                                };
                            }
                        }
                        else
                        {
                            return new CalculatorResult
                            {
                                IsSuccess = true,
                                Value = (ReadTerm<int>(terms)).ToString(),
                                Message = "Is not a SuperPalindrome number",
                            };
                        }
                    }
                case Operation.ChangeSign:
                    {
                        return new CalculatorResult
                        {
                            IsSuccess = true,
                            Value = ((-1) * ReadTerm<double>(terms)).ToString(),
                            Message = "Result"
                        };
                    }
                default:
                    break;
            }
            return new CalculatorResult();
        }

        private T ReadTerm<T>(string[] input)
        {
            if (input.Length > 0)
            {
                return (T)ConvertStringToType<T>(input[0]);
            }

            return default(T);
        }

        private List<T> ReadTerms<T>(string[] input)
        {
            var result = new List<T>();
            for (int i = 0; i < input.Length; i++)
            {
                result.Add((T)ConvertStringToType<T>(input[i]));
            }

            return result;
        }

        private object ConvertStringToType<T>(string valueToConvert)
        {
            if (typeof(T) == typeof(double))
            {
                return ConvertToDouble(valueToConvert);
            }

            if (typeof(T) == typeof(int))
            {
                return ConvertToInteger(valueToConvert);
            }

            return default;
        }

        private static double ConvertToDouble(string valueToConvert)
        {
            double.TryParse(valueToConvert, out double result);
            return result;
        }

        private static int ConvertToInteger(string valueToConvert)

        {
            if (int.TryParse(valueToConvert, out int result))
            {
                return result;
            }
            else
            {
                //must give the error result
                return result;
            }
        }

        private static bool IsPrime(int valueToCheck)
        {
            bool isPrime = true;
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

            return isPrime;
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
    

    public static int Reverse(int a)
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
