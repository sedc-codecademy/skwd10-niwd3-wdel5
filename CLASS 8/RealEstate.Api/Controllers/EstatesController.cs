using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Interfaces;

namespace RealEstate.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private readonly IEstatesService _estatesService;

        public EstatesController(IEstatesService estatesService)
        {
            _estatesService = estatesService;
        }

        [HttpGet]
        public  async Task<IActionResult> Estates()
        {
            try
            {
                return Ok(await _estatesService.GetEstates());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Estates(long id)
        {
            try
            {
                return Ok(await _estatesService.GetEstateById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
