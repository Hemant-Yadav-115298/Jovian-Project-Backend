using Microsoft.EntityFrameworkCore;
using Jovian_Project_Backend.Models;

namespace Jovian_Project_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<InfoActor> ActorsActor { get; set; }
        public DbSet<Threat> Threat { get; set; }
        public DbSet<ThreatDiagram> ThreatDiagram { get; set; }
        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoActor>()
            .HasOne(ia => ia.Info)
            .WithMany(i => i.InfoActors)
            .HasForeignKey(ia => ia.InfoID);

            modelBuilder.Entity<InfoActor>()
            .HasOne(ia => ia.Actor)
            .WithMany(a => a.InfoActors)
            .HasForeignKey(ia => ia.ActorID);

            modelBuilder.Entity<Threat>()
            .HasOne(t => t.Info)
            .WithMany(i => i.Threats)
            .HasForeignKey(t => t.InfoID);

            modelBuilder.Entity<ThreatDiagram>()
            .HasOne(td => td.Info)
            .WithMany(i => i.ThreatDiagrams)
            .HasForeignKey(td => td.InfoID);

            modelBuilder.Entity<Login>(entity =>
    {
        entity.HasKey(l => l.ID);

        entity.HasIndex(l => l.Email).IsUnique();

        entity.Property(l => l.Email)
              .IsRequired()
              .HasMaxLength(200);

        entity.Property(l => l.Password)
              .IsRequired()
              .HasMaxLength(255);

        entity.HasOne(l => l.Actor)
              .WithMany()
              .HasForeignKey(l => l.ActorID)
              .OnDelete(DeleteBehavior.Restrict);
    });


        }


    }
}
