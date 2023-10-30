using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwiftShip.Database.Entities;
using SwiftShip.Database.Enums;

namespace SwiftShip.Database
{
    public class SwiftShipDbContext : DbContext
    {
        public SwiftShipDbContext()
        {
        }

        public SwiftShipDbContext(DbContextOptions<SwiftShipDbContext> options) : base(options)
        {
        }

        public DbSet<Parcel> Parcel { get; set; }

        public DbSet<Stage> Stage { get; set; }

        public DbSet<StageHistory> StageHistory { get; set; }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
               .Entity<Stage>()
               .Property(d => d.Description)
               .HasConversion(new EnumToStringConverter<StageType>());

            var values = Enum.GetValues(typeof(StageType))
                           .Cast<object>()
                           .Select(value => new Stage() { Description = (StageType)value, Id = (int)value })
                           .ToList();

            modelBuilder.Entity<Stage>().HasData(values);
        }
    }

}
