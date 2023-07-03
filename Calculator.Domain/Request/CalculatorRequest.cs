
namespace Calculator.Domain.Request
{
    public class MultipleTermOperationCalculatorRequest
    {
        public string CalculatorInput { get; set; }
        public CalculatorState CalculatorState { get; set; }
    }

        public class SingleTermOperationCalculatorRequest
    {
        public string CalculatorInput { get; set; }
    }
}
