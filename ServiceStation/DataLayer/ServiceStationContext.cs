using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataLayer
{
    public class ServiceStationContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<CarDTO> Cars { get; set; }
        public DbSet<CarTechnicalConditionDTO> CarTechnicalConditions { get; set; }
        public DbSet<InspectorDTO> Inspectors { get; set; }
        public DbSet<OwnerDTO> Owners { get; set; }

        public ServiceStationContext(DbContextOptions<ServiceStationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
