using Calculator.Domain.Request;
using Calculator.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;

namespace Calculator.Logic
{
    public class CalculatorService
    {
        private ICalculatorLogic _calculatorLogic;

        public CalculatorService(ICalculatorLogic calculatorLogic)
        {
            _calculatorLogic = calculatorLogic;
        }
        public CalculatorResponse GetCalculatorResponse(CalculatorRequest request)
        {
            var calculatorResponse = new CalculatorResponse();
            var strings = request.ButtonClicked.Split('_').ToList();

            SetTheCalculatorStateIfExists(request);
            if (strings != null && strings.Count > 0)
            {
                _calculatorLogic.AddTerm(strings[0]);

                if (strings[1] == "=")
                {
                    DoMultipleTermOperation(calculatorResponse);
                }
                else
                {
                    DoSingleTermOperation(calculatorResponse, strings);
                }
            }
            return calculatorResponse;
        }

        private void DoSingleTermOperation(CalculatorResponse calculatorResponse, List<string> strings)
        {
            Operation operation = CheckAndSetOperation(strings);
            switch (operation)
            {
                case Operation.IsPrime:
                case Operation.AbsoluteValue:
                case Operation.IsOddOrEven:
                case Operation.SquareRoot:
                case Operation.IsSuperpalindrome:
                case Operation.IsPalindrome:
                case Operation.Reverse:
                case Operation.ChangeSign:
                    DoSingleTermOperation(calculatorResponse);
                    break;
                default:
                    GetTheCalculatorState(calculatorResponse);
                    break;
            }
        }

        private Operation CheckAndSetOperation(List<string> strings)
        {
            var operation = Enum.Parse<Operation>(strings[1]);
            _calculatorLogic.SetCurrentOperation(operation);
            return operation;
        }

        private void DoMultipleTermOperation(CalculatorResponse calculatorResponse)
        {
            calculatorResponse.CalculatorResult = _calculatorLogic.DoMultipleTermOperation();
        }

        private void DoSingleTermOperation(CalculatorResponse calculatorResponse)
        {
            calculatorResponse.CalculatorResult = _calculatorLogic.DoSingleTermOperation();
        }

        private void GetTheCalculatorState(CalculatorResponse calculatorResponse)
        {
            calculatorResponse.CalculatorState = _calculatorLogic.GetCalculatorState();
        }

        private void SetTheCalculatorStateIfExists(CalculatorRequest request)
        {
            if (request.CalculatorState != null)
            {
                _calculatorLogic.SetState(request.CalculatorState);
            }
        }
    }
}
