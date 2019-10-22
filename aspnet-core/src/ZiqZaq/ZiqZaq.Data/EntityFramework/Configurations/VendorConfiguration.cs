using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZiqZaq.Shared.Models.Entities;

namespace ZiqZaq.Data.EntityFramework.Configurations
{
    internal class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.Property(p => p.AgencyName).IsRequired().HasMaxLength(256);
            builder.Property(p => p.AgencyEmail).IsRequired().HasMaxLength(256);
            builder.Property(p => p.HomePhone).HasMaxLength(32);
            builder.Property(p => p.Website).HasMaxLength(256);
            builder.Property(p => p.FacebookAddress).HasMaxLength(16);
            builder.Property(p => p.InstagramAddress).HasMaxLength(32);
            builder.Property(p => p.TwitterAddress).HasMaxLength(32);

            builder.HasOne(p => p.ApplicationUser)
                .WithOne(p => p.Vendor)
                .HasForeignKey<Vendor>(p => p.UserId);
        }
    }
}