using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TLC.Registry.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Breeder> Breeders { get; set; }
    public DbSet<Classification> Classifications { get; set; }
    public DbSet<DnaStatus> DnaStatuses { get; set; }
    public DbSet<Registry> Registries { get; set; }
}
