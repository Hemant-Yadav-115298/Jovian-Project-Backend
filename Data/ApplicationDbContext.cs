using Microsoft.EntityFrameworkCore;
using Jovian_Project_Backend.Models;

namespace Jovian_Project_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<InfoActor> ActorsActor { get; set; }
        public DbSet<Threat> Threat { get; set; }
        public DbSet<ThreatDiagram> ThreatDiagram { get; set; }

        //hello this is just to check git

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
