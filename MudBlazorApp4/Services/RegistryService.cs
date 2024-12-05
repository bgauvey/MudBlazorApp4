using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TLC.Registry.Contracts;
using TLC.Registry.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TLC.Registry.Services
{
 
    public class RegistryService : IRegistryService
    {
        private readonly ApplicationDbContext _context;

        public RegistryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Data.Registry[]> GetRegistries()
        {
            return await _context.Registries.ToArrayAsync();
        }

        public async Task<Data.Registry?> GetRegistry(int id)
        {
            var registry = await _context.Registries.FindAsync(id);
            return registry;
        }

        public async Task UpdateRegistry(int id, Data.Registry registry)
        {
            if (id != registry.RegistrationId)
            {
                throw new ArgumentException("Id is not valid for this model.");
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
                    throw new ApplicationException("Not found.");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Data.Registry> CreateRegistry(Data.Registry registry)
        {
            _context.Registries.Add(registry);
            await _context.SaveChangesAsync();

            return registry;
        }

        public async Task DeleteRegistry(int id)
        {
            var registry = await _context.Registries.FindAsync(id);
            if (registry == null)
            {
                throw new ApplicationException($"Unable to delete registry {id}");
            }

            _context.Registries.Remove(registry);
            await _context.SaveChangesAsync();
        }

        private bool RegistryExists(int id)
        {
            return _context.Registries.Any(e => e.RegistrationId == id);
        }
    }
}
