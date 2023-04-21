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
                        ExecuteSumOperation(firstTerm, secondTerm, result);
                    }
                    break;
                case CalculatorOperation.Subtract:
                    {
                        ExecuteSubtractOperation(firstTerm, secondTerm, result);
                    }
                    break;
                case CalculatorOperation.Multiply:
                    {
                        ExecuteMultiplyOperation(firstTerm, secondTerm, result);
                    }
                    break;
                case CalculatorOperation.Divide:
                    {
                        ExecuteDivideOperation(firstTerm, secondTerm, result);
                    }
                    break;
                case CalculatorOperation.RaiseNumberToPower:
                    {
                        ExecuteRaiseNumberToPower(firstTerm, secondTerm, result);
                    }
                    break;
                case CalculatorOperation.SquareRoot:
                    {
                        ExecuteSquareRootOperation(firstTerm, result);
                    }
                    break;
                case CalculatorOperation.NumberParity:
                    {
                        ExecuteNumberParityOperation(firstTerm, result);
                    }
                    break;
                case CalculatorOperation.MirroredNumber:
                    {
                        ExecuteGetMirroredOperation(firstTerm, result);
                    }
                    break;
                case CalculatorOperation.IsPrime:
                    {
                        ExecutePrimeOperation(firstTerm, result);
                    }
                    break;
                case CalculatorOperation.PalindromeSuperPalindrome:
                    {
                        ExecutePalindromeOrSuperPalindromeOperation(firstTerm, result);
                    }
                    break;
                case CalculatorOperation.LeastCommonMultiple:
                    {
                        ExecuteLeastCommonMultiple(firstTerm, secondTerm, result);

                    }
                    break;
                case CalculatorOperation.BiggestCommunalDivisor:
                    {
                        ExecuteBiggestCommunalDivisor(firstTerm, secondTerm, result);
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        private static void ExecuteSumOperation(string firstTerm, string secondTerm, CalculatorResult result)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = termOne + termTwo;
            result.Value = resultValue.ToString();
        }
        private static void ExecuteSubtractOperation(string firstTerm, string secondTerm, CalculatorResult result)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = termOne - termTwo;
            result.Value = resultValue.ToString();
        }
        private static void ExecuteMultiplyOperation(string firstTerm, string secondTerm, CalculatorResult result)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = termOne * termTwo;
            result.Value = resultValue.ToString();
        }
        private static void ExecuteDivideOperation(string firstTerm, string secondTerm, CalculatorResult result)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = termOne / termTwo;
            result.Value = resultValue.ToString();
        }
        private static void ExecuteRaiseNumberToPower(string firstTerm, string secondTerm, CalculatorResult result)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var termTwo = CalculatorConverterStringToNumber.ConvertToDouble(secondTerm);
            var resultValue = Math.Pow(termOne, termTwo);
            result.Value = resultValue.ToString();
        }
        private static void ExecuteSquareRootOperation(string firstTerm, CalculatorResult result)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
            var resultValue = Math.Sqrt(termOne);
            result.Value = resultValue.ToString();
        }
        private static void ExecuteNumberParityOperation(string firstTerm, CalculatorResult result)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
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
        }
        private static void ExecuteGetMirroredOperation(string firstTerm, CalculatorResult result)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
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
        }
        private static uint GetMirroredNumber(uint number)
        {
            uint mirrored = 0;
            while (number != 0)
            {
                mirrored = mirrored * 10 + number % 10;
                number /= 10;
            }
            return mirrored;
        }
        private static void ExecutePrimeOperation(string firstTerm, CalculatorResult result)
        {
            var termOne = CalculatorConverterStringToNumber.ConvertToDouble(firstTerm);
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
        }
        private static void ExecutePalindromeOrSuperPalindromeOperation(string firstTerm, CalculatorResult result)
        {
            uint termOne = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
            uint mirrored = GetMirroredNumber(termOne);
            var numberraisedtopower = Math.Pow(termOne, 2);
            var mirrored2 = GetMirroredNumber((uint)numberraisedtopower);
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
        }
        private static void ExecuteLeastCommonMultiple(string firstTerm, string secondTerm, CalculatorResult result)
        {
            var number1 = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
            var number2 = CalculatorConverterStringToNumber.ConvertToUInt(secondTerm);
            var number1Aux = number1;
            var number2Aux = number2;
            CheckLeastCommonMultiple(number1, number2, ref number1Aux, ref number2Aux);
            result.Message = $"LCM between {number1} and {number2} is {number2Aux}.";
            result.Value = $"{number2Aux}";
        }
        private static void CheckLeastCommonMultiple(uint number1, uint number2, ref uint number1Aux, ref uint number2Aux)
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
        private static void ExecuteBiggestCommunalDivisor(string firstTerm, string secondTerm, CalculatorResult result)
        {
            var number1 = CalculatorConverterStringToNumber.ConvertToUInt(firstTerm);
            var number2 = CalculatorConverterStringToNumber.ConvertToUInt(secondTerm);
            var number1Aux = number1;
            var number2Aux = number2;
            CheckBiggestCommunalDivisor(ref number1Aux, ref number2Aux);
            result.Message = $"BCD between {number1} and {number2} is {number2Aux}.";
            result.Value = $"{number2Aux}";
        }
        private static void CheckBiggestCommunalDivisor(ref uint number1Aux, ref uint number2Aux)
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
        private static bool HasDivisors(uint convertedFirstTerm)
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
        private static bool IsNaturalNumber(double value)
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
