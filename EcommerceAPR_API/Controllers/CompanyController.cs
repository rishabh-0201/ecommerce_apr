using EcommerceAPR.Data;
using EcommerceAPR.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPR.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ApplicationDbContext context, ILogger<CompanyController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            try
            {
                var companies = await _context.Companies
                    .Select(c => new CompanyDTO
                    {
                        CompanyId = c.CompanyId,
                        CompanyName = c.CompanyName
                    })
                    .ToListAsync();

                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving companies.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompanyById(int id)
        {
            try
            {
                var company = await _context.Companies
                    .Where(c => c.CompanyId == id)
                    .Select(c => new CompanyDTO
                    {
                        CompanyId = c.CompanyId,
                        CompanyName = c.CompanyName
                    })
                    .FirstOrDefaultAsync();

                if (company == null)
                {
                    return NotFound($"Company with ID {id} not found.");
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving company with ID {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }

        }
    }
        
}
