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
        [HttpGet]
        public CalculatorResponse GetResponse([FromQuery]CalculatorRequest calculatorRequest)
        {
            var calculatorService = new CalculatorService(new CalculatorLogic(new CalculatorError(), new CalculatorValidator(), new StringToNumberConvertor()));
            return calculatorService.GetCalculatorResponse(calculatorRequest);
        }
    }
}
