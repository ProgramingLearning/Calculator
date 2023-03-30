using Calculator.Logic.Errors;
using System.Collections.Generic;

namespace Calculator.Logic
{
    public class StringToNumberConvertor : IStringToNumberConvertor
    {
        public T ReadTerm<T>(List<string> input)
        {
            if (input.Count > 0)
            {
                return (T)ConvertStringToType<T>(input[0]);
            }
            return default(T);
        }

        public List<T> ReadTerms<T>(List<string> input)
        {
            if (input.Count > 0)
            {
                var result = new List<T>();
                for (int i = 0; i < input.Count; i++)
                {
                    result.Add((T)ConvertStringToType<T>(input[i]));
                }
                return result;
            }
            throw new CalculatorException(Error.NoTermSelected);
        }
         
        private static object ConvertStringToType<T>(string valueToConvert)
        {
            if (typeof(T) == typeof(double))
            {
                return ConvertToDouble(valueToConvert);
            }
            if (typeof(T) == typeof(int))
            {
                return ConvertToInteger(valueToConvert);
            }
            throw new CalculatorException(Error.TypeOfDateNotImplemented);
        }

        private static double ConvertToDouble(string valueToConvert)
        {
            if (double.TryParse(valueToConvert, out double result))
            {
                return result;
            }
            else
            {
                throw new CalculatorException(Error.IsNotADouble);
            }
        }

        private static int ConvertToInteger(string valueToConvert)
        {
            if (int.TryParse(valueToConvert, out int result))
            {
                return result;
            }
            else
            {
                throw new CalculatorException(Error.IsNotAnInteger);
            }
        }
    }
}

