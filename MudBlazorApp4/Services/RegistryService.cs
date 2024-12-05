using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TLC.Registry.Data;

namespace TLC.Registry.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistryService : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RegistryService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Data.Registry>>> GetRegistries()
        {
            return await _context.Registries.ToListAsync();
        }

        // GET: api/RegistryService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Data.Registry>> GetRegistry(int id)
        {
            var registry = await _context.Registries.FindAsync(id);

            if (registry == null)
            {
                return NotFound();
            }

            return registry;
        }

        // PUT: api/RegistryService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutRegistry(int id, Data.Registry registry)
        {
            if (id != registry.RegistrationId)
            {
                return BadRequest();
            }

            _context.Entry(registry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistryExists(id))
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

        // POST: api/RegistryService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Data.Registry>> PostRegistry(Data.Registry registry)
        {
            _context.Registries.Add(registry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistry", new { id = registry.RegistrationId }, registry);
        }

        // DELETE: api/RegistryService/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRegistry(int id)
        {
            var registry = await _context.Registries.FindAsync(id);
            if (registry == null)
            {
                return NotFound();
            }

            _context.Registries.Remove(registry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistryExists(int id)
        {
            return _context.Registries.Any(e => e.RegistrationId == id);
        }
    }
}
