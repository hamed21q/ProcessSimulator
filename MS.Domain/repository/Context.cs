using Microsoft.EntityFrameworkCore;
using MS.Domain.repository.Mappings;

namespace MS.Domain.repository
{
    public class Context : DbContext
    {
        public DbSet<Process> Processes { get; set; }
        public DbSet<Simulation> Simulations { get; set; }
        public Context(DbContextOptions<Context> context) : base(context) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProcessMapping());
            modelBuilder.ApplyConfiguration(new SimulationMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
