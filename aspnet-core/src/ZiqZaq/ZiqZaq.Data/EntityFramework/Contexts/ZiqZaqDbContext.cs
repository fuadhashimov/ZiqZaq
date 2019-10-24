using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZiqZaq.Data.EntityFramework.Configurations;
using ZiqZaq.Shared.Models.Entities;

namespace ZiqZaq.Data.EntityFramework.Contexts
{
    public class ZiqZaqDbContext : IdentityDbContext<ApplicationUser>
    {
        public ZiqZaqDbContext(DbContextOptions<ZiqZaqDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new VendorConfiguration());
            builder.ApplyConfiguration(new TourConfiguration());

            base.OnModelCreating(builder);
        }
    }
}