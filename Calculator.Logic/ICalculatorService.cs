using Calculator.Domain.Request;
using Calculator.Domain.Response;

namespace Calculator.Logic
{
    public interface ICalculatorService
    {
        CalculatorResponse GetCalculatorResponseForMultipleTermOperation(CalculatorRequest request);
        CalculatorResponse GetCalculatorResponseForSingleTermOperation(CalculatorRequest request);
    }
}