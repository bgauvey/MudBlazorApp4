using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TLC.Registry.Client.Contracts;
using TLC.Registry.Client;

namespace TLC.Registry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistryController : ControllerBase
    {

        private readonly IRegistryService _registryService; 

        public RegistryController(IRegistryService registryService)
        {
            _registryService = registryService;
        }

        // GET: api/Registry
        [HttpGet]
        public async Task<ActionResult<Client.Models.Registry[]>> GetRegistries()
        {
            return await _registryService.GetRegistries();
        }

        // GET: api/Registry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client.Models.Registry>> GetRegistry(int id)
        {
            var registry = await _registryService.GetRegistry(id);

            if (registry == null)
            {
                return NotFound();
            }

            return registry;
        }

        // PUT: api/Registry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutRegistry(int id, Client.Models.Registry registry)
        {
            if (id != registry.RegistrationId)
            {
                return BadRequest();
            }

            try
            {
                await _registryService.UpdateRegistry(id, registry);
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

        // POST: api/Registry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Client.Models.Registry>> PostRegistry(Client.Models.Registry registry)
        {
            registry = await _registryService.CreateRegistry(registry);
 

            return CreatedAtAction("GetRegistry", new { id = registry.RegistrationId }, registry);
        }

        // DELETE: api/Registry/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRegistry(int id)
        {

            await _registryService.DeleteRegistry(id);

            return NoContent();
        }

        private bool RegistryExists(int id)
        {
            var registries = _registryService.GetRegistries().Result.ToList();
            return registries.Any(e => e.RegistrationId == id);
        }
    }
}
