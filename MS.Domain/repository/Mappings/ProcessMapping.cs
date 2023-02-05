using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Domain.repository.Mappings
{
    public class ProcessMapping : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.ToTable("Processes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Address);
            builder.Property(x => x.Size);

            builder.HasOne(x => x.Simulation).WithMany(x => x.Processs).HasForeignKey(x => x.SimulationId);
        }
    }
}
