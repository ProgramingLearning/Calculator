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
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        [HttpGet("MultipleTermOperation")]
        public ActionResult<CalculatorResponse> GetMultipleTermResponse([FromQuery] CalculatorRequest calculatorRequest)
        {
            if (IsValidTermInput(calculatorRequest))
            {
                
            return Ok(_calculatorService.GetCalculatorResponseForMultipleTermOperation(calculatorRequest));
            }
            return BadRequest();
        }

        [HttpGet("SingleTermOperation")]
        public ActionResult<CalculatorResponse> GetSingleTermResponse([FromQuery] CalculatorRequest calculatorRequest)
        {
            if (IsValidTermInput(calculatorRequest))
            {
                
                return Ok(_calculatorService.GetCalculatorResponseForSingleTermOperation(calculatorRequest));
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
