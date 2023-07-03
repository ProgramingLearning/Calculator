using Calculator.Domain.Request;
using Calculator.Domain.Response;

namespace Calculator.Logic
{
    public interface ICalculatorService
    {
        MultipleTermOperationCalculatorResponse GetCalculatorResponseForMultipleTermOperation(MultipleTermOperationCalculatorRequest request);
        SingleTermOperationCalculatorResponse GetCalculatorResponseForSingleTermOperation(SingleTermOperationCalculatorRequest request);
    }
}