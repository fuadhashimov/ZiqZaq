using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZiqZaq.Shared.Models.Entities;

namespace ZiqZaq.Data.EntityFramework.Configurations
{
    internal class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(p => p.Name);
            builder.Property(p => p.DepartureLocation);
            builder.Property(p => p.Destination);
            builder.Property(p => p.DepartureTime);
            builder.Property(p => p.ArrivalTime);
            builder.Property(p => p.AdultPrice);
            builder.Property(p => p.ChildPrice);
            builder.Property(p => p.InfantPrice);
            builder.Property(p => p.Description);
        }
    }
}
