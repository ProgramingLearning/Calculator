using Calculator.Domain.Request;
using Calculator.Domain.Response;

namespace Calculator.Logic
{
    public interface ICalculatorLogic
    {
        CalculatorResult DoMultipleTermOperation();

        CalculatorResult DoSingleTermOperation();

        CalculatorState GetCalculatorState();

        void SetState (CalculatorState state);

        void AddTerm(string term);

        void SetLastTerm(string term);

        void ResetTerms();

        void SetCurrentOperation(Operation operation);

        Operation GetCurrentOperation();

        bool ShouldPerformOperationForCurrentTerms(Operation newOperation);

        bool ShouldRepeatLastOperation(Operation newOperation);
        string GetLastTerm();
    }
}
