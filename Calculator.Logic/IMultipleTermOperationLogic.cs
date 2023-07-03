using Calculator.Domain.Request;
using Calculator.Domain.Response;

namespace Calculator.Logic
{
    public interface IMultipleTermOperationLogic
    {
        CalculatorResult DoMultipleTermOperation();

        CalculatorState GetCalculatorState();

        void SetState (CalculatorState state);

        void AddTerm(string term);

        void SetLastTerm(string term);

        void ResetTerms();

        void SetCurrentOperation(MultipleTermOperation operation);

        MultipleTermOperation GetCurrentOperation();

        bool ShouldPerformOperationForCurrentTerms(MultipleTermOperation newOperation);

        bool ShouldRepeatLastOperation(MultipleTermOperation newOperation);
        string GetLastTerm();
    }
}
