using BackCustomerWithRelations.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackCustomerWithRelations.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<MstPais> MstPais { get; set; }
        public DbSet<MstCiudad> MstCiudad { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstCiudad>()
                .HasOne(c => c.MstPais)
                .WithMany()
                .HasForeignKey(c => c.IdPais)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.MstPais)
                .WithMany()
                .HasForeignKey(c => c.IdPais)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.MstCiudad)
                .WithMany()
                .HasForeignKey(c => c.IdCiudad)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }  
}
