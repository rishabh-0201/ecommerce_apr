using EcommerceRPA.DataConnection;
using EcommerceRPA.DTO;
using EcommerceRPA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceRPA.Controllers
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
                    CityName = v.City.CityName,
                    StateName = v.City.State.StateName,
                    CompanyName=v.Company.CompanyName,
                    StateId = v.City.StateId,
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
        public async Task<IActionResult> PostVendor(CreateVendorDTO vendorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var vendor = new Vendor
                {
                    VendorName = vendorDTO.VendorName,
                    ContactPerson = vendorDTO.ContactPerson,
                    PhoneNumber = vendorDTO.PhoneNumber,
                    Email = vendorDTO.Email,
                    Address = vendorDTO.Address,
                    CityId = vendorDTO.CityId,

                    CompanyId = vendorDTO.CompanyId,
                    CreatedAt = DateTime.Now
                };

                _context.Vendors.Add(vendor);
                await _context.SaveChangesAsync();



                //return CreatedAtAction(nameof(GetVendor), new { id = vendor.VendorId }, vendorResponse);
                return StatusCode(200, "Success");


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

            return StatusCode(200, "Success");
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
