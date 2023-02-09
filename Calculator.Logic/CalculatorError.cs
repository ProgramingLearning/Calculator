namespace Calculator.Logic
{
    public class CalculatorError
    {


        public void HandleCalculatorException(CalculatorException ex)
        {
            switch (ex.ErrorType)
            {
                case Error.None:
                    break;
                case Error.DivideBy0:
                    {
                        //Message = "Cannot divide by 0";
                    }
                    break;
                case Error.NoOperationSelected:
                    {
                        //Message = "Select operation: +, -, * or /";
                    }
                    break;
                case Error.IsNotAnInteger:
                    {
                        //Message = "The number is not an Integer";
                    }
                    break;
                case Error.Error4:
                    break;
                default:
                    break;
            }
        }
    }
}
