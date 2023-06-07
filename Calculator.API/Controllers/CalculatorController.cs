using Calculator.Domain.Request;
using Calculator.Domain.Response;
using Calculator.Logic;
using Calculator.Logic.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorLogic _calculatorLogic;

        public CalculatorController(ICalculatorLogic calculatorLogic)
        {
            _calculatorLogic = calculatorLogic;
        }

        [HttpGet("MultipleTermOperation")]
        public ActionResult<CalculatorResponse> GetMultipleTermResponse([FromQuery] CalculatorRequest calculatorRequest)
        {
            return new CalculatorResponse();
        }
    }
}
