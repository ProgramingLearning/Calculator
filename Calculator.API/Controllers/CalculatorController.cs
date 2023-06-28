using Calculator.Domain.Request;
using Calculator.Domain.Response;
using Calculator.Logic;
using Calculator.Logic.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("MultipleTermOperation")]
        public ActionResult<MultipleTermOperationCalculatorResponse> GetMultipleTermResponse([FromQuery] MultipleTermOperationCalculatorRequest calculatorRequest)
        {
            if (IsValidRequest(calculatorRequest))
            {
                var calculatorService = new CalculatorService(new CalculatorLogic(new CalculatorError(), new CalculatorValidator(), new StringToNumberConvertor()));
                return Ok(calculatorService.GetCalculatorResponseForMultipleTermOperation(calculatorRequest));
            }
            return BadRequest();
        }

        [HttpGet("SingleTermOperation")]
        public ActionResult<SingleTermOperationCalculatorResponse> GetSingleTermResponse([FromQuery] SingleTermOperationCalculatorRequest calculatorRequest)
        {
            if (IsValidRequest(calculatorRequest))
            {
                var calculatorService = new CalculatorService(new CalculatorLogic(new CalculatorError(), new CalculatorValidator(), new StringToNumberConvertor()));
                return Ok(calculatorService.GetCalculatorResponseForSingleTermOperation(calculatorRequest));
            }
            return BadRequest();
        }

        private bool IsValidRequest(object calculatorRequest)
        {
            string calculatorInput = GetCalculatorInput(calculatorRequest);
            return IsValidTermCount(calculatorInput);
        }

        private string GetCalculatorInput(object calculatorRequest)
        {
            return calculatorRequest switch
            {
                MultipleTermOperationCalculatorRequest multipleTermRequest => multipleTermRequest.CalculatorInput,
                SingleTermOperationCalculatorRequest singleTermRequest => singleTermRequest.CalculatorInput,
                _ => null
            };
        }

        private bool IsValidTermCount(string calculatorInput)
        {
            var strings = calculatorInput?.Split('_');
            return strings?.Length == 2;
        }
    }
}
 