using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSIMS.Data;

namespace StudentSIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressContext _context;

        public AddressesController(AddressContext context)
        {
            _context = context;
        }
        
        // GET /api/addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Address.ToListAsync();
        }
        
        // PUT: api/addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.addressId)
            {
                return BadRequest();
            }

            if (!AddressExists(id))
            {
                return BadRequest();
            }

            var updateAddress = await _context.Address.FirstOrDefaultAsync(a => a.studentId == address.studentId);
            _context.Entry(updateAddress).State = EntityState.Modified;

            updateAddress.streetNumber = address.streetNumber;
            updateAddress.street = address.street;
            updateAddress.suburb = address.suburb;
            updateAddress.city = address.city;
            updateAddress.postcode = address.postcode;
            updateAddress.country = address.country;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        

        // Adds a new address for a student, using their student id.
        // POST /api/addresses/{id}
        [HttpPost("{id}")]
        public async Task<ActionResult<Address>> PostAddress(int id, Address address)
        {
            address.studentId = id;
            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.addressId }, address);
        }

        // DELETE: api/addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }
        
        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.addressId == id);
        }
    }
}