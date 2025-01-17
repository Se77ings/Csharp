using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wishlist.Components.Lista;

namespace Wishlist.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Wishlist.Components.Lista.Lista> Lista { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuração de chave estrangeira (opcional)
            builder.Entity<Lista>()
                .HasOne(l => l.User)
                .WithMany() // Isso significa que um usuário pode ter várias Listas
                .HasForeignKey(l => l.UserId);
        }
    }
}
