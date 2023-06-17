using Calculator.Domain.Request;
using Calculator.Domain.Response;
using Calculator.Logic;
using Calculator.Logic.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("MultipleTermOperation")]
        public ActionResult<CalculatorResponse> GetMultipleTermResponse([FromQuery] CalculatorRequest calculatorRequest)
        {
            if (IsValidTermInput(calculatorRequest))
            {
                var calculatorService = new CalculatorService(new CalculatorLogic(new CalculatorError(), new CalculatorValidator(), new StringToNumberConvertor()));
            return Ok(calculatorService.GetCalculatorResponseForMultipleTermOperation(calculatorRequest));
            }
            return BadRequest();
        }

        [HttpGet("SingleTermOperation")]
        public ActionResult<CalculatorResponse> GetSingleTermResponse([FromQuery] CalculatorRequest calculatorRequest)
        {
            if (IsValidTermInput(calculatorRequest))
            {
                var calculatorService = new CalculatorService(new CalculatorLogic(new CalculatorError(), new CalculatorValidator(), new StringToNumberConvertor()));
                return Ok(calculatorService.GetCalculatorResponseForSingleTermOperation(calculatorRequest));
            }
            return BadRequest();
        }
        private bool IsValidTermInput(CalculatorRequest calculatorRequest)
        {
            var strings = calculatorRequest.ButtonClicked.Split('_').ToList();
            return strings != null && strings.Count == 2;
        }
    }
}
