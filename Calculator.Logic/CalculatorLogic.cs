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
                    break;
                case Operation.Subtract:
                    break;
                case Operation.Multiply:
                    break;
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
                    break;
                case Operation.IsOddOrEven:
                    break;
                case Operation.Power:
                    break;
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
                    break;
                case Operation.Reverse:
                    break;
                case Operation.Palindrome:
                    break;
                case Operation.Superpalindrome:
                    break;
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

            return default(T);
        }

        private static double ConvertToDouble(string valueToConvert)
        {
            double.TryParse(valueToConvert, out double result);
            return result;
        }
    }
}
