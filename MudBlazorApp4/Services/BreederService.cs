using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TLC.Registry.Contracts;
using TLC.Registry.Data;

namespace TLC.Registry.Services
{

    public class BreederService : ControllerBase, IBreederService
    {
        private readonly ApplicationDbContext _context;

        public BreederService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BreederService
        [HttpGet]
        public async Task<IEnumerable<Breeder>> GetBreeders()
        {
            return await _context.Breeders.ToListAsync();
        }

        // GET: api/BreederService/5
        [HttpGet("{id}")]
        public async Task<Breeder> GetBreeder(int id)
        {
            var breeder = await _context.Breeders.FindAsync(id);

            if (breeder == null)
            {
                throw new ApplicationException("Breeder not found");
            }

            return breeder;
        }

        // PUT: api/BreederService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task PutBreeder(int id, Breeder breeder)
        {
            if (id != breeder.BreederId)
            {
                throw new ApplicationException("Breeder ID does not match");
            }

            _context.Entry(breeder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreederExists(id))
                {
                    throw new ApplicationException("Breeder not found");
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/BreederService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Breeder> PostBreeder(Breeder breeder)
        {
            _context.Breeders.Add(breeder);
            await _context.SaveChangesAsync();

            return breeder; //CreatedAtAction("GetBreeder", new { id = breeder.BreederId }, breeder);
        }

        // DELETE: api/BreederService/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteBreeder(int id)
        {
            var breeder = await _context.Breeders.FindAsync(id);
            if (breeder == null)
            {
                throw new ApplicationException("Breeder not found");
            }

            _context.Breeders.Remove(breeder);
            await _context.SaveChangesAsync();
        }

        private bool BreederExists(int id)
        {
            return _context.Breeders.Any(e => e.BreederId == id);
        }
    }
}
