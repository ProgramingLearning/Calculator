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
        public CalculatorResponse GetCalculatorResponseForMultipleTermOperation(CalculatorRequest request)
        {
            var calculatorResponse = new CalculatorResponse();
            var strings = request.ButtonClicked.Split('_').ToList();
            SetTheCalculatorStateIfExistsInRequest(request);
            _calculatorLogic.AddTerm(strings[0]);
            ProcessOperationForMultipleTerm(calculatorResponse, strings[1]);
            return calculatorResponse;
        }

        public CalculatorResponse GetCalculatorResponseForSingleTermOperation(CalculatorRequest request)
        {
            var calculatorResponse = new CalculatorResponse();
            var strings = request.ButtonClicked.Split('_').ToList();
            _calculatorLogic.AddTerm(strings[0]);
            ProcessOperationForSingleTerm(calculatorResponse, strings[1]);
            return calculatorResponse;
        }

        private void ProcessOperationForMultipleTerm(CalculatorResponse calculatorResponse, string strings)
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
        }

        private void ProcessOperationForSingleTerm(CalculatorResponse calculatorResponse, string strings)
        {
            var operation = Enum.Parse<Operation>(strings);
            _calculatorLogic.SetCurrentOperation(operation);
            calculatorResponse.CalculatorResult = _calculatorLogic.DoSingleTermOperation();
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

