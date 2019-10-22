using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZiqZaq.Shared.Models.Entities;

namespace ZiqZaq.Data.EntityFramework.Configurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(256);
        }
    }
}
