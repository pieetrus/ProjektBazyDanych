using Microsoft.EntityFrameworkCore;

namespace ProjektyBazyDanych.Entities
{
    public class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
        {
        }
        public DbSet<Projekt> Projekty { get; set; }
        public DbSet<Rodzaj> Rodzaje { get; set; }
        public DbSet<Status> Statusy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Konfiguracja połączenia do bazy danych
            optionsBuilder.UseSqlServer(connectionString: "Server=.;Database=Projekty;MultipleActiveResultSets=true;Trusted_Connection=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Projekt>()
         .Property(p => p.Kwota)
         .HasColumnType("decimal(18, 2)");

                modelBuilder.Entity<Projekt>()
        .Property(p => p.Kwota)
        .HasPrecision(18, 2);
        }
    }
}
