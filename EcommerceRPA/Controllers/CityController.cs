using EcommerceRPA.DataConnection;
using EcommerceRPA.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceRPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CityController> _logger;

        public CityController(ApplicationDbContext context, ILogger<CityController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities()
        {
            try
            {
                var cities = await _context.Cities
                    .Select(c => new CityDTO
                    {
                        CityId = c.CityId,
                        CityName = c.CityName,
                        StateId = c.StateId
                    })
                    .ToListAsync();

                return Ok(cities);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while retrieving cities.");


                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving cities.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDTO>> GetCityById(int id)
        {
            try
            {
                var city = await _context.Cities
                    .Where(c => c.CityId == id)
                    .Select(c => new CityDTO
                    {
                        CityId = c.CityId,
                        CityName = c.CityName,
                        StateId = c.StateId
                    })
                    .FirstOrDefaultAsync();

                if (city == null)
                {
                    return NotFound($"City with ID {id} not found.");
                }

                return Ok(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving city with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }


        [HttpGet("state/{stateId}")]
        public async Task<ActionResult<CityDTO>> GetCityByStateId(int stateId)
        {
            try
            {
                var city = await _context.Cities
                    .Where(c => c.StateId == stateId)
                    .Select(c => new CityDTO
                    {
                        CityId = c.CityId,
                        CityName = c.CityName,
                        StateId = c.StateId
                    })
                    .ToListAsync();

                if (city == null)
                {
                    return NotFound($"City with ID {stateId} not found.");
                }

                return Ok(city);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"An error occurred while retrieving city with stateId {stateId}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }



    }

}
