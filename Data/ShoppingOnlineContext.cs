using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Models; // importa il namespace giusto

namespace ShoppingOnline.Data
{
    public class ShoppingOnlineContext : DbContext
    {
        public ShoppingOnlineContext(DbContextOptions<ShoppingOnlineContext> options) : base(options) { }
        public DbSet<CatalogoScarpe> catalogo_Scarpes { get; set; }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura la proprietà Price come decimal(18,2)
        modelBuilder.Entity<CatalogoScarpe>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        base.OnModelCreating(modelBuilder);
    }

}
