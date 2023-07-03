using Calculator.Domain.Request;
using Calculator.Domain.Response;

namespace Calculator.Logic
{
    public interface ISingleTermOperationLogic
    {

        CalculatorResult DoSingleTermOperation(SingleTermOperation operation, string term);

    }
}
