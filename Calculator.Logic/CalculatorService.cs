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

        public MultipleTermOperationCalculatorResponse GetCalculatorResponseForMultipleTermOperation(MultipleTermOperationCalculatorRequest request)
        {
            var calculatorResponse = new MultipleTermOperationCalculatorResponse();
            var strings = request.CalculatorInput.Split('_').ToList();
            SetTheCalculatorStateIfExistsInRequest(request);
            _calculatorLogic.SetLastTerm(strings[0]);
            _calculatorLogic.AddTerm(strings[0]);
            ProcessOperationForMultipleTerm(calculatorResponse, strings[1]);
            return calculatorResponse;
        }

        public SingleTermOperationCalculatorResponse GetCalculatorResponseForSingleTermOperation(SingleTermOperationCalculatorRequest request)
        {
            var calculatorResponse = new SingleTermOperationCalculatorResponse();
            var strings = request.CalculatorInput.Split('_').ToList();
            _calculatorLogic.AddTerm(strings[0]);
            ProcessOperationForSingleTerm(calculatorResponse, strings[1]);
            return calculatorResponse;
        }

        private void ProcessOperationForMultipleTerm(MultipleTermOperationCalculatorResponse calculatorResponse, string strings)
        {
            if (strings == "=")
            {
                calculatorResponse.CalculatorResult = _calculatorLogic.DoMultipleTermOperation();
            }
            else
            {
                var operation = Enum.Parse<Operation>(strings);
                _calculatorLogic.SetCurrentOperation(operation);
                calculatorResponse.CalculatorState = _calculatorLogic.GetCalculatorState();
            }
            calculatorResponse.LastTerm = _calculatorLogic.GetLastTerm();
            calculatorResponse.Operation = _calculatorLogic.GetCurrentOperation();
        }

        private void ProcessOperationForSingleTerm(SingleTermOperationCalculatorResponse calculatorResponse, string strings)
        {
            var operation = Enum.Parse<Operation>(strings);
            _calculatorLogic.SetCurrentOperation(operation);
            calculatorResponse.CalculatorResult = _calculatorLogic.DoSingleTermOperation();
        }

        private void SetTheCalculatorStateIfExistsInRequest(MultipleTermOperationCalculatorRequest request)
        {
            if (request.CalculatorState != null)
            {
                _calculatorLogic.SetState(request.CalculatorState);
            }
        }
    }
}


