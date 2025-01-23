using Microsoft.EntityFrameworkCore;

namespace BeneficioContribuinte.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Beneficio> Beneficios { get; set; }
        public DbSet<Contribuinte> Contribuintes { get; set; }
    }
}
