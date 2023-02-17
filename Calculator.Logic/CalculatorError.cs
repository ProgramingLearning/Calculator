namespace Calculator.Logic
{

    public class CalculatorError: ICalculatorError
    {

        public CalculatorResult HandleCalculatorException(CalculatorException ex)
        {
            switch (ex.ErrorType)
            {
                case Error.None:
                    break;
                case Error.DivideBy0:
                    {
                        return new CalculatorResult
                        {
                            IsSuccess = false,
                            Message = "Can not divide by 0"
                        };
                    }
                case Error.NoOperationSelected:
                    {
                        return new CalculatorResult
                        {
                            IsSuccess = false,
                            Message ="Select operation: +, -, *or / "
                        };
                    }
                case Error.IsNotAnInteger:
                    {
                        return new CalculatorResult
                        {
                            IsSuccess = false,
                            Message = "The number is not an Integer"
                        };
                    }
                case Error.ToFewTerms:
                    {
                        return new CalculatorResult
                        {
                            IsSuccess = false,
                            Message = "To few terms"
                        };
                    }
                case Error.IsNotADouble:
                    {
                        return new CalculatorResult
                        {
                            IsSuccess = false,
                            Message = "The number is not a Double"
                        };
                    }

                default:
                    break;
            }
            return new CalculatorResult();
        }
    }
}
