using Microsoft.EntityFrameworkCore;

namespace Recode_MVC_Dot_Net.Models
{
    public class DestinoDBContext : DbContext
    {
        public DestinoDBContext(DbContextOptions<DestinoDBContext> options)
          : base(options)
        { }

        public DbSet<Destino> Destino { get; set; }
    }
}