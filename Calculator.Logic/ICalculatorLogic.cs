namespace Calculator.Logic
{
    public interface ICalculatorLogic
    {
        CalculatorResult DoMultipleTermOperation();

        CalculatorResult DoSingleTermOperation();

        void AddTerm(string term);

        void ResetTerms();

        void SetCurrentOperation(Operation operation);

        Operation GetCurrentOperation();

        bool ShouldPerformOperationForCurrentTerms(Operation newOperation);

        bool ShouldRepeatLastOperation(Operation newOperation);
    }
}
