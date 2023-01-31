using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;

namespace PS.Infrustructure
{
    public class ProcessMapping : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.ToTable("Process");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BurstTime);
            builder.Property(x => x.ArrivalTime);
        }
    }
}
