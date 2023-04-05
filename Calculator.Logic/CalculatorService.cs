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

            SetTheCalculatorStateIfExistsInRequest(request);
            if (strings != null && strings.Count > 0)
            {
                _calculatorLogic.AddTerm(strings[0]);

                if (strings[1] == "=")
                {
                    calculatorResponse.CalculatorResult = _calculatorLogic.DoMultipleTermOperation();
                }
                else
                {
                    Operation operation = ParseStringToEnumOperation(strings);
                    _calculatorLogic.SetCurrentOperation(operation);
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
                            calculatorResponse.CalculatorResult = _calculatorLogic.DoSingleTermOperation();
                            break;
                        default:
                            calculatorResponse.CalculatorState = _calculatorLogic.GetCalculatorState();
                            break;
                    }
                }
            }
            return calculatorResponse;
        }
            private static Operation ParseStringToEnumOperation(List<string> strings)
        {
            var operation = Enum.Parse<Operation>(strings[1]);
            return operation;
        }

        private void SetTheCalculatorStateIfExistsInRequest(CalculatorRequest request)
        {
            if (request.CalculatorState != null)
            {
                _calculatorLogic.SetState(request.CalculatorState);
            }
        }
    }
}
