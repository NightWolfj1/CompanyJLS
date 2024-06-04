using Microsoft.EntityFrameworkCore;
using CompanyJLS.Models;
using System.Security.Cryptography;

namespace CompanyJLS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.HasKey(col => col.id);
                tb.Property(col => col.id).UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.NombreCompleto).HasMaxLength(100);
                tb.Property(col => col.Correo).HasMaxLength(100);
                tb.Property(col => col.Contraseña).HasMaxLength(100);

            });

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}
