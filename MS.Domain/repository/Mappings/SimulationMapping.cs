using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Domain.repository.Mappings
{
    public class SimulationMapping : IEntityTypeConfiguration<Simulation>
    {
        public void Configure(EntityTypeBuilder<Simulation> builder)
        {
            builder.ToTable("Simulations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Algorithem);
            builder.Property(x => x.StorageSize);

            builder.HasMany(x => x.Processs).WithOne(x => x.Simulation).HasForeignKey(x => x.SimulationId);
        }
    }
}
