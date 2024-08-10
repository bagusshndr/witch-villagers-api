using Microsoft.AspNetCore.Mvc;
using WitchVillagerApi.Models;
using WitchVillagerApi.Village.Services;

namespace WitchVillagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillagerController : ControllerBase
    {
        private readonly IVillagerService _service;

        public VillagerController(IVillagerService service)
        {
            _service = service;
        }

        [HttpPost("calculate-average")]
        public IActionResult CalculateAverage([FromBody] VillagerInputModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid input data.");
            }

            double averageKilled = _service.CalculateAverageKilled(
                model.AgeOfDeathA, model.YearOfDeathA,
                model.AgeOfDeathB, model.YearOfDeathB);

            if (averageKilled == -1)
            {
                return BadRequest("Invalid age or year of birth before witch took control.");
            }

            return Ok(new { AverageKilled = averageKilled });
        }
    }
}
