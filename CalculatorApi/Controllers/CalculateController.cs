using Calculate.Common.Models;
using Calculate.Service.Interface.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculateService _calculateService;
        public CalculateController(ICalculateService calculateService)
        {
            this._calculateService = calculateService;
        }

        // To test from Browser you can use this http://localhost:58627/api/calculate?values=8*8
        [HttpGet]
        public IActionResult Get(string values, string iPAddress ="")
        { 

            if(iPAddress =="")
            {
                iPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }  
            if(values!=null)
            {
                return Ok (_calculateService.CalculateValue(values, iPAddress));
            }
            else
            {
               return NotFound();
            }
            
        }
    }
}