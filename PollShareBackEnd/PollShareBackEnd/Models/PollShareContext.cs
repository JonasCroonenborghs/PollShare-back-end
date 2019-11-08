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
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Stem> Stemmen { get; set; }
        public DbSet<Antwoord> Antwoorden { get; set; }
        public DbSet<Melding> Meldingen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PollGebruiker>().ToTable("PollGebruiker");
            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
            modelBuilder.Entity<Poll>().ToTable("Poll");
            modelBuilder.Entity<Stem>().ToTable("Stem");
            modelBuilder.Entity<Antwoord>().ToTable("Antwoord");
            modelBuilder.Entity<Melding>().ToTable("Melding");
        }
    }
}
