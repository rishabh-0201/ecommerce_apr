using EcommerceRPA.DataConnection;
using EcommerceRPA.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceRPA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StateController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<StateController> _logger;

        public StateController(ApplicationDbContext context, ILogger<StateController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateDTO>>> GetStates()
        {
            try
            {
                var states = await _context.States
                    .Select(s => new StateDTO
                    {
                        StateId = s.StateId,
                        StateName = s.StateName
                    })
                    .ToListAsync();

                return Ok(states);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving states.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StateDTO>> GetStateById(int id)
        {
            try
            {
                var state = await _context.States
                    .Where(s => s.StateId == id)
                    .Select(s => new StateDTO
                    {
                        StateId = s.StateId,
                        StateName = s.StateName
                    })
                    .FirstOrDefaultAsync();

                if (state == null)
                {
                    return NotFound($"State with ID {id} not found.");
                }

                return Ok(state);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving state with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
