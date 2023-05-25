using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Logic
{
    public static class CalculatorLogic
    {
        public static CalculatorResult PerformOperation(string firstTerm, string secondTerm, CalculatorOperation calculatorOperation)
        {
            CalculatorResult result = new CalculatorResult();
            switch (calculatorOperation)
            {
                case CalculatorOperation.None:
                    {
                    }
                    break;
                case CalculatorOperation.Sum:
                    {
                        ExecuteSumOperation(firstTerm, secondTerm);
                    }
                    break;
                case CalculatorOperation.Subtract:
                    {
                        ExecuteSubtractOperation(firstTerm, secondTerm);
                    }
                    break;
                case CalculatorOperation.Multiply:
                    {
                        ExecuteMultiplyOperation(firstTerm, secondTerm);
                    }
                    break;
                case CalculatorOperation.Divide:
                    {
                        ExecuteDivideOperation(firstTerm, secondTerm);
                    }
                    break;
                case CalculatorOperation.RaiseNumberToPower:
                    {
                        ExecuteRaiseNumberToPower(firstTerm, secondTerm);
                    }
                    break;
                case CalculatorOperation.SquareRoot:
                    {
                        ExecuteSquareRootOperation(firstTerm);
                    }
                    break;
                case CalculatorOperation.NumberParity:
                    {
                        ExecuteNumberParityOperation(firstTerm);
                    }
                    break;
                case CalculatorOperation.MirroredNumber:
                    {
                        ExecuteGetMirroredOperation(firstTerm);
                    }
                    break;
                case CalculatorOperation.IsPrime:
                    {
                        ExecutePrimeOperation(firstTerm);
                    }
                    break;
                case CalculatorOperation.PalindromeSuperPalindrome:
                    {
                        ExecutePalindromeOrSuperPalindromeOperation(firstTerm);
                    }
                    break;
                case CalculatorOperation.LeastCommonMultiple:
                    {
                        ExecuteLeastCommonMultiple(firstTerm, secondTerm);
                    }
                    break;
                case CalculatorOperation.BiggestCommunalDivisor:
                    {
                        ExecuteBiggestCommunalDivisor(firstTerm, secondTerm);
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        public static CalculatorResult ExecuteSumOperation(string firstTerm, string secondTerm)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = termOne + termTwo;
            var result = new CalculatorResult { Value = resultValue.ToString() };
            return result;
        }
        public static CalculatorResult ExecuteSubtractOperation(string firstTerm, string secondTerm)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = termOne - termTwo;
            var result = new CalculatorResult { Value = resultValue.ToString() };
            return result;
        }
        public static CalculatorResult ExecuteMultiplyOperation(string firstTerm, string secondTerm)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = termOne * termTwo;
            var result = new CalculatorResult { Value = resultValue.ToString() };
            return result;
        }
        public static CalculatorResult ExecuteDivideOperation(string firstTerm, string secondTerm)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = termOne / termTwo;
            var result = new CalculatorResult { Value = resultValue.ToString() };
            return result;
        }
        public static CalculatorResult ExecuteRaiseNumberToPower(string firstTerm, string secondTerm)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = Math.Pow(termOne, termTwo);
            var result = new CalculatorResult { Value = resultValue.ToString() };
            return result;
        }
        public static CalculatorResult ExecuteSquareRootOperation(string firstTerm)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var resultValue = Math.Sqrt(termOne);
            var result = new CalculatorResult { Value = resultValue.ToString() };
            return result;
        }
        public static CalculatorResult ExecuteNumberParityOperation(string firstTerm)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
            var result = new CalculatorResult();
            if (termOne % 2 == 0)
            {
                result.Message = "The number is even.";
                result.Value = $"{termOne}";
            }
            else
            {
                result.Message = "The number is odd.";
                result.Value = $"{termOne}";
            }
            return result;
        }
        public static CalculatorResult ExecuteGetMirroredOperation(string firstTerm)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var result = new CalculatorResult();
            if (IsNaturalNumber(termOne))
            {
                uint number = Convert.ToUInt32(firstTerm);
                var resultValue = GetMirroredNumber(number);
                result.Value = resultValue.ToString();
            }
            else
            {
                result.Message = "Please enter a natural number.";
            }
            return result;
        }
        public static uint GetMirroredNumber(uint number)
        {
            uint mirrored = 0;
            while (number != 0)
            {
                mirrored = mirrored * 10 + number % 10;
                number /= 10;
            }
            return mirrored;
        }
        public static CalculatorResult ExecutePrimeOperation(string firstTerm)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var result = new CalculatorResult();
            if (IsNaturalNumber(termOne))
            {
                uint convertedFirstTerm = Convert.ToUInt32(firstTerm);
                if (convertedFirstTerm <= 1)
                {
                    result.Message = $"{convertedFirstTerm} is not a prime number.";
                    result.Value = $"{convertedFirstTerm}";
                }
                else if (convertedFirstTerm == 2)
                {
                    result.Message = $"{convertedFirstTerm} is  a prime number.";
                    result.Value = $"{convertedFirstTerm}";

                }
                else
                {
                    if (HasDivisors(convertedFirstTerm))
                    {
                        result.Message = $"{convertedFirstTerm} is  a prime number.";
                        result.Value = $"{convertedFirstTerm}";

                    }
                    else
                    {
                        result.Message = $"{convertedFirstTerm} is not a prime number.";
                        result.Value = $"{convertedFirstTerm}";

                    }
                }
            }
            else
            {
                result.Message = $" {firstTerm} is not a natural number.";
                result.Value = $"{firstTerm}";

            }
            return result;
        }
        public static CalculatorResult ExecutePalindromeOrSuperPalindromeOperation(string firstTerm)
        {
            uint termOne = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
            uint mirrored = GetMirroredNumber(termOne);
            var numberraisedtopower = Math.Pow(termOne, 2);
            var mirrored2 = GetMirroredNumber((uint)numberraisedtopower);
            var result = new CalculatorResult();
            if (termOne == mirrored)
            {
                if (numberraisedtopower == mirrored2)
                {
                    result.Message = $"{firstTerm} is a superpalindrome.";
                    result.Value = firstTerm;

                }
                else
                {
                    result.Message = $"{firstTerm} is a palindrome.";
                    result.Value = firstTerm;
                }
            }
            else
            {
                result.Message = $"{firstTerm} is not a palindrome.";
                result.Value = firstTerm;

            }
            return result;
        }
        public static CalculatorResult ExecuteLeastCommonMultiple(string firstTerm, string secondTerm)
        {
            var number1 = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
            var number2 = CalculatorConverterStringToNumber.ConvertToUInt(secondTerm);
            var number1Aux = number1;
            var number2Aux = number2;
            var result = new CalculatorResult();
            CheckLeastCommonMultiple(number1, number2, ref number1Aux, ref number2Aux);
            result.Message = $"LCM between {number1} and {number2} is {number2Aux}.";
            result.Value = $"{number2Aux}";
            return result;
        }
        public static void CheckLeastCommonMultiple(uint number1, uint number2, ref uint number1Aux, ref uint number2Aux)
        {
            while (number1Aux != number2Aux)
            {
                if (number1Aux < number2Aux)
                {
                    number1Aux += number1;
                }
                else
                {
                    number2Aux += number2;
                }
            }
        }
        public static CalculatorResult ExecuteBiggestCommunalDivisor(string firstTerm, string secondTerm)
        {
            var number1 = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
            var number2 = CalculatorConverterStringToNumber.ConvertToUInt(secondTerm);
            var number1Aux = number1;
            var number2Aux = number2;
            var result = new CalculatorResult();
            CheckBiggestCommunalDivisor(ref number1Aux, ref number2Aux);
            result.Message = $"BCD between {number1} and {number2} is {number2Aux}.";
            result.Value = $"{number2Aux}";
            return result;

        }
        public static void CheckBiggestCommunalDivisor(ref uint number1Aux, ref uint number2Aux)
        {
            while (number1Aux != number2Aux)
            {
                if (number1Aux > number2Aux)
                {
                    number1Aux -= number2Aux;
                }
                else
                {
                    number2Aux -= number1Aux;
                }
            }
        }
        public static bool HasDivisors(uint convertedFirstTerm)
        {
            for (double divisor = 2; divisor <= Math.Sqrt(convertedFirstTerm); divisor++)
            {
                if (convertedFirstTerm % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsNaturalNumber(double value)
        {
            if (Math.Floor(value) == value && value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
