using Microsoft.AspNetCore.Mvc;
using ZoneDeterminer;

namespace ZoneDeterminerWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZoneDeterminerController : Controller
    {
        private readonly IDetermineZone _determineZone;
        private readonly ILogger<ZoneDeterminerController> logger;

        public ZoneDeterminerController(IDetermineZone determineZone, ILogger<ZoneDeterminerController> logger)
        {
            _determineZone = determineZone;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetZoneDetermine([FromBody] ZoneDeterminerParameters zoneDeterminerParameters)
        {
            return Ok(_determineZone.Determine(zoneDeterminerParameters));
        }
    }
}
