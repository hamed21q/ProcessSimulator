using Microsoft.EntityFrameworkCore;
using PS.Domain;

namespace PS.Infrustructure
{
    public class SimulatorContext : DbContext
    {
        public DbSet<Process> processes { get; set; }
        public SimulatorContext(DbContextOptions<SimulatorContext> context) : base(context)
        {

        }
    }
}