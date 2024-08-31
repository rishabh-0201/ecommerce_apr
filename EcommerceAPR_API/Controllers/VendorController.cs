using EcommerceAPR.Data;
using EcommerceAPR.DTO;
using EcommerceAPR.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorResponseDTO>>> GetVendors()
        {
            try
            {
                var vendors = await _context.Vendors
                                             .Include(v => v.Company)
                                             .Include(v => v.City)
                                             .ThenInclude(c => c.State)
                                             .ToListAsync();

                var vendorDtos = vendors.Select(v => new VendorResponseDTO
                {
                    VendorId = v.VendorId,
                    VendorName = v.VendorName,
                    ContactPerson = v.ContactPerson,
                    PhoneNumber = v.PhoneNumber,
                    Email = v.Email,
                    Address = v.Address,
                    CityId = v.CityId,
                    StateId = v.StateId,
                    CompanyId = v.CompanyId,
                    CreatedAt = v.CreatedAt
                }).ToList();

                return Ok(vendorDtos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET: api/vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorResponseDTO>> GetVendor(int id)
        {
            try
            {
                var vendor = await _context.Vendors
                                           .Include(v => v.Company)
                                           .Include(v => v.City)
                                           .ThenInclude(c => c.State)
                                           .FirstOrDefaultAsync(v => v.VendorId == id);

                if (vendor == null)
                {
                    return NotFound($"Vendor with ID {id} not found.");
                }

                var vendorDto = new VendorResponseDTO
                {
                    VendorId = vendor.VendorId,
                    VendorName = vendor.VendorName,
                    ContactPerson = vendor.ContactPerson,
                    PhoneNumber = vendor.PhoneNumber,
                    Email = vendor.Email,
                    Address = vendor.Address,
                    CityId = vendor.CityId,
                    StateId = vendor.StateId,
                    CompanyId = vendor.CompanyId,
                    CreatedAt = vendor.CreatedAt
                };

                return Ok(vendorDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<VendorResponseDTO>> PostVendor(CreateVendorDTO vendorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var vendor = new Vendor
                {
                    VendorName = vendorDto.VendorName,
                    ContactPerson = vendorDto.ContactPerson,
                    PhoneNumber = vendorDto.PhoneNumber,
                    Email = vendorDto.Email,
                    Address = vendorDto.Address,
                    CityId = vendorDto.CityId,
                    StateId = vendorDto.StateId,
                    CompanyId = vendorDto.CompanyId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Vendors.Add(vendor);
                await _context.SaveChangesAsync();

                var vendorResponse = new VendorResponseDTO
                {
                    VendorId = vendor.VendorId,
                    VendorName = vendor.VendorName,
                    ContactPerson = vendor.ContactPerson,
                    PhoneNumber = vendor.PhoneNumber,
                    Email = vendor.Email,
                    Address = vendor.Address,
                    CityId = vendor.CityId,
                    StateId = vendor.StateId,
                    CompanyId = vendor.CompanyId,
                    CreatedAt = vendor.CreatedAt
                };

                return CreatedAtAction(nameof(GetVendor), new { id = vendor.VendorId }, vendorResponse);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Unable to save changes to the database.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(int id, UpdateVendorDTO vendorDto)
        {
            if (id != vendorDto.VendorId)
            {
                return BadRequest("Vendor ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound($"Vendor with ID {id} not found.");
            }

            vendor.VendorName = vendorDto.VendorName;
            vendor.ContactPerson = vendorDto.ContactPerson;
            vendor.PhoneNumber = vendorDto.PhoneNumber;
            vendor.Email = vendorDto.Email;
            vendor.Address = vendorDto.Address;
            vendor.CityId = vendorDto.CityId;
            vendor.StateId = vendorDto.StateId;
            vendor.CompanyId = vendorDto.CompanyId;

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
                {
                    return NotFound($"Vendor with ID {id} not found.");
                }
                else
                {
                    return StatusCode(500, "Concurrency error occurred while updating the vendor.");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            try
            {
                var vendor = await _context.Vendors.FindAsync(id);
                if (vendor == null)
                {
                    return NotFound($"Vendor with ID {id} not found.");
                }

                _context.Vendors.Remove(vendor);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        private bool VendorExists(int id)
        {
            return _context.Vendors.Any(e => e.VendorId == id);
        }
    }
}
