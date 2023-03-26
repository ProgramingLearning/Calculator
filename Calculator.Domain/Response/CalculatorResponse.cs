using Calculator.Domain.Request;

namespace Calculator.Domain.Response
{
    public class CalculatorResponse
    {
        public CalculatorState CalculatorState { get; set; }
        public CalculatorResult CalculatorResult { get; set; }
    }
}
