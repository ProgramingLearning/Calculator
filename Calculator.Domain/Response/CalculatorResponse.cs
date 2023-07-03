using Calculator.Domain.Request;

namespace Calculator.Domain.Response
{
    public class MultipleTermOperationCalculatorResponse
    {
        public CalculatorState CalculatorState { get; set; }
        public CalculatorResult CalculatorResult { get; set; }
        public MultipleTermOperation Operation { get; set; }
        public string LastTerm { get; set; }
    }

    public class SingleTermOperationCalculatorResponse
    {
        public CalculatorState CalculatorState { get; set; }
        public CalculatorResult CalculatorResult { get; set; }
    }
}
