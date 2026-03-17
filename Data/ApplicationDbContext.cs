using BCOAT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BCOAT.Data
{
    // Inherits from IdentityDbContext to include all ASP.NET Core Identity tables
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Your entities
        public DbSet<Movie> Movies => Set<Movie>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>(entity =>
            {
                entity.Property(m => m.Title).HasMaxLength(200).IsRequired();
                entity.Property(m => m.Description).HasMaxLength(2000);
                entity.Property(m => m.ImagePath).HasMaxLength(500);
                entity.Property(m => m.Rating).HasDefaultValue(1);
                entity.Property(m => m.UploadedDate).HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}