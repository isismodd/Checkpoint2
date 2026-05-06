using Checkpoint2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Checkpoint2.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Jogo> Jogos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogo>()
                .Property(j => j.PrecoLocacao)
                .HasPrecision(18, 2); // 18 dígitos no total, 2 após a vírgula
        }
    }
}