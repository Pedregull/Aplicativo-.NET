using Microsoft.EntityFrameworkCore;

namespace Recode_Api.Models
{
    public class DestinoDBContext : DbContext
    {
        public DestinoDBContext(DbContextOptions<DestinoDBContext> options)
          : base(options)
        { }

        public DbSet<Destino> Destino { get; set; }

    }
}
