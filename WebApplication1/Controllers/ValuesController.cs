using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        public CalculateService _service = new CalculateService();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello! This is calculator speaking. Nice to meet you.");            
        }                
        
        [HttpPost("math")]
        public IActionResult GetMaths([FromBody] MathModel MathModel)
        {
            if (!ModelState.IsValid) { return BadRequest("Invalid data."); }
            if (MathModel == null)
            {
                return BadRequest("Invalid data.");
            }
            var serializedmathModel = JsonConvert.SerializeObject(MathModel, MyJsonSettings.settings);
            Console.WriteLine("Serialized MathModel");
            Console.WriteLine(JsonConvert.SerializeObject(MathModel, MyJsonSettings.settings));
            Result result = _service.CalculateResult(MathModel.Maths.Operation);            
            return Ok(new { message = "Result is ready", result= result,});
        }                 
    }
}
