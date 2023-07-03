using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Domain.Response;
using Calculator.Domain.Request;
using Calculator.Logic.Errors;

namespace Calculator.Logic
{
    public class MultipleTermOperationLogic : IMultipleTermOperationLogic
    {
        private ICalculatorError _calculatorError;
        private ICalculatorValidator _calculatorValidator;
        private IStringToNumberConvertor _stringToNumberConverter;
        private CalculatorState _calculatorState;
        private string _lastTerm;

        public MultipleTermOperationLogic(ICalculatorError calculatorError, ICalculatorValidator calculatorValidator, IStringToNumberConvertor stringToNumberConverter)
        {
            _calculatorError = calculatorError;
            _calculatorValidator = calculatorValidator;
            _stringToNumberConverter = stringToNumberConverter;
            _calculatorState = new CalculatorState();
        }

        public CalculatorResult DoMultipleTermOperation()
        {
            if (ShouldRepeatLastOperation(_calculatorState.CurrentMultipleTermOperation))
            {
                AddLastTermUsed();
            }
            return HandleErrorsWithTryAndCatchAndDoCalculation();
        }

        private CalculatorResult HandleErrorsWithTryAndCatchAndDoCalculation()
        {
            try
            {
                return DoCalculation();
            }
            catch (CalculatorException ex)
            {
                return _calculatorError.HandleCalculatorException(ex);
            }
        }

        private CalculatorResult DoCalculation()
        {
            _lastTerm = _calculatorState.Terms.LastOrDefault();
            _calculatorValidator.ValidateMultipleTermOperation(_calculatorState.CurrentMultipleTermOperation);
            CalculatorResult calculatorResult = null;
            switch (_calculatorState.CurrentMultipleTermOperation)
            {
                case MultipleTermOperation.Sum:
                    {
                        calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForMultipleTermsOperation, (x, y) => { return x + y; }));
                        break;
                    }
                case MultipleTermOperation.Subtract:
                    {
                        calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForMultipleTermsOperation, (x, y) => { return x - y; }));
                        break;
                    }
                case MultipleTermOperation.Multiply:
                    {
                        calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForMultipleTermsOperation, (x, y) => { return x * y; }));
                        break;
                    }
                case MultipleTermOperation.Divide:
                    {
                        calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForDivision, (x, y) => { return x / y; }));
                        break;
                    }
                case MultipleTermOperation.Power:
                    {
                        calculatorResult = GetDefaultCalculatorResult(ValidateAndGetOperationResultForTerms(ValidateTermsForMultipleTermsOperation, (x, y) => { return Math.Pow(x, y); }));
                        break;
                    }
                default:
                    calculatorResult = new CalculatorResult();
                    break;
            }

            return calculatorResult;
        }

        private List<double> GetDoubleTerms()
        {
            return _stringToNumberConverter.ReadTerms<double>(_calculatorState.Terms);
        }

        private void ValidateTermsForDivision(List<double> termsList)
        {
            _calculatorValidator.ValidateTermsForDivision(termsList);
        }

        private void ValidateTermsForMultipleTermsOperation(List<double> termsList)
        {
            _calculatorValidator.ValidateTermsForMultipleTermsOperation(termsList);
        }

        private double ValidateAndGetOperationResultForTerms(Action<List<double>> validationMethod, Func<double, double, double> operationMethod)
        {
            var termsList = GetDoubleTerms();
            validationMethod(termsList);
            var resultValue = termsList.First();
            termsList.Skip(1).ToList().ForEach(x => { resultValue = operationMethod(resultValue, x); });
            return resultValue;
        }

        public void SetCurrentOperation(MultipleTermOperation operation)
        {
            _calculatorState.CurrentMultipleTermOperation = operation;
        }

        public bool ShouldPerformOperationForCurrentTerms(MultipleTermOperation newOperation)
        {
            return newOperation != _calculatorState.CurrentMultipleTermOperation && _calculatorState.Terms.Count > 1;
        }

        public bool ShouldRepeatLastOperation(MultipleTermOperation newOperation)
        {
            return newOperation == _calculatorState.CurrentMultipleTermOperation && _calculatorState.Terms.Count == 1;
        }

        public void AddTerm(string term)
        {
            _calculatorState.Terms.Add(term);
        }

        public void AddLastTermUsed()
        {
            _calculatorState.Terms.Add(_lastTerm);
        }

        public void SetLastTerm(string term)
        {
            _lastTerm = term;
        }

        public string GetLastTerm()
        {
            return _lastTerm;
        }

        public void ResetTerms()
        {
            _calculatorState.Terms = new List<string>();
        }

        public void SetState(CalculatorState state)
        {
            _calculatorState = state;
        }

        public CalculatorState GetCalculatorState()
        {
            return _calculatorState;
        }

        private static CalculatorResult GetDefaultCalculatorResult(double resultValue)
        {
            return GetCalculatorResult(true, resultValue, "Result");
        }

        private static CalculatorResult GetCalculatorResult(bool isSuccess, double resultValue, string message)
        {
            return new CalculatorResult
            {
                IsSuccess = isSuccess,
                Message = message,
                Value = resultValue.ToString()
            };
        }
        public MultipleTermOperation GetCurrentOperation()
        {
            return _calculatorState.CurrentMultipleTermOperation;
        }
    }
}

