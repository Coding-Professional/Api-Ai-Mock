using Microsoft.AspNetCore.Mvc;
using System; 

namespace ApiAiMock.Controllers
{
    [ApiController]
    [Route("api/analysis")] 
    public class ConfidenceAPIController : ControllerBase
    {
        // This method will create a GET endpoint at the URL: /api/analysis
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok(new { Status = "Confidence API is up and running!", Timestamp = DateTime.UtcNow });
        }
    }
}