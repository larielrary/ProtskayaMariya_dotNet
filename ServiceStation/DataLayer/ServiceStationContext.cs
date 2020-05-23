using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ServiceStationContext : DbContext
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
