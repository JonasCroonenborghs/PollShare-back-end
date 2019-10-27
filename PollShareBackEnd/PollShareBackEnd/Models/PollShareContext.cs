using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollShareBackEnd.Models
{
    public class PollShareContext: DbContext
    {
        public PollShareContext(DbContextOptions<PollShareContext> options)
            : base(options) { }

        public DbSet<PollGebruiker> PollGebruikers { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PollGebruiker>().ToTable("PollGebruiker");
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
        }
    }
}
