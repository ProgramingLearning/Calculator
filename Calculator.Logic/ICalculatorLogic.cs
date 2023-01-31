namespace Calculator.Logic
{
    public interface ICalculatorLogic
    {
        CalculatorResult DoStuff(Operation operation, params string[] input);
    }
}
