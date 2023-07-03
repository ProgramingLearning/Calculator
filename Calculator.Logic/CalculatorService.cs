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
        private ISingleTermOperationLogic _singleTermOperationLogic;
        private IMultipleTermOperationLogic _multipleTermOperationLogic;

        public CalculatorService(ISingleTermOperationLogic singleTermOperationLogic, IMultipleTermOperationLogic multipleTermOperationLogic)
        {
            _singleTermOperationLogic = singleTermOperationLogic;
            _multipleTermOperationLogic = multipleTermOperationLogic;
        }

        public MultipleTermOperationCalculatorResponse GetCalculatorResponseForMultipleTermOperation(MultipleTermOperationCalculatorRequest request)
        {
            var calculatorResponse = new MultipleTermOperationCalculatorResponse();
            var strings = request.CalculatorInput.Split('_').ToList();
            SetTheCalculatorStateIfExistsInRequest(request);
            _multipleTermOperationLogic.SetLastTerm(strings[0]);
            _multipleTermOperationLogic.AddTerm(strings[0]);
            calculatorResponse= ProcessOperationForMultipleTerm(strings[1]);
            return calculatorResponse;
        }

        public SingleTermOperationCalculatorResponse GetCalculatorResponseForSingleTermOperation(SingleTermOperationCalculatorRequest request)
        {
            var calculatorResponse = new SingleTermOperationCalculatorResponse();
            var strings = request.CalculatorInput.Split('_').ToList();
            var operation = Enum.Parse<SingleTermOperation>(strings[1]);
            calculatorResponse.CalculatorResult = _singleTermOperationLogic.DoSingleTermOperation(operation, strings[0]);
            return calculatorResponse;
        }

        private MultipleTermOperationCalculatorResponse ProcessOperationForMultipleTerm(string strings)
        {
            var calculatorResponse = new MultipleTermOperationCalculatorResponse();
            if (strings == "=")
            {
                calculatorResponse.CalculatorResult = _multipleTermOperationLogic.DoMultipleTermOperation();
            }
            else
            {
                var operation = Enum.Parse<MultipleTermOperation>(strings);
                _multipleTermOperationLogic.SetCurrentOperation(operation);
                calculatorResponse.CalculatorState = _multipleTermOperationLogic.GetCalculatorState();
            }
            calculatorResponse.LastTerm = _multipleTermOperationLogic.GetLastTerm();
            calculatorResponse.Operation = _multipleTermOperationLogic.GetCurrentOperation();

            return calculatorResponse;
        }

        private void SetTheCalculatorStateIfExistsInRequest(MultipleTermOperationCalculatorRequest request)
        {
            if (request.CalculatorState != null)
            {
                _multipleTermOperationLogic.SetState(request.CalculatorState);
            }
        }
    }
}




