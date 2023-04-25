namespace Calculator.Logic
{
    public class CalculatorConverterStringToNumber
    {
        public static double ConvertToDouble(string valueToConvert)
        {
            if (double.TryParse(valueToConvert, out double result))
            {
                return result;
            }
            else
            {
                throw new CalculatorException(CalculatorExceptionCause.InvalidNumberInput, valueToConvert);
            }
        }
        public static uint ConvertToUInt(string valueToConvert)
        {
            if (uint.TryParse(valueToConvert, out uint result))
            {
                return result;
            }
            else
            {
                throw new CalculatorException(CalculatorExceptionCause.ThisOperationRequiersNaturalOperants, valueToConvert);
            }
        }


    }
}
