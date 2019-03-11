using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sampledata.Models
{
    public partial class cmsContext : DbContext
    {
        public cmsContext()
        {
        }

        public cmsContext(DbContextOptions<cmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductCode).HasMaxLength(50);

                entity.Property(e => e.ProductCost).HasColumnType("money");

                entity.Property(e => e.ProductExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasKey(e => e.ClaimId)
                    .HasName("PK__tmp_ms_x__EF2E139B9F5978F9");

                entity.Property(e => e.ClaimType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
