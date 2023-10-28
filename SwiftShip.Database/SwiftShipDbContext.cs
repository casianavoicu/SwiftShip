using Microsoft.EntityFrameworkCore;
using SwiftShip.Database.Entities;

namespace SwiftShip.Database
{
    public class SwiftShipDbContext : DbContext
    {
        public SwiftShipDbContext(DbContextOptions options) : base(options)
        {
        }

        protected SwiftShipDbContext()
        {
        }

        public DbSet<Parcel> Parcel { get; set; }

        public DbSet<Stage> Stage { get; set; }

        public DbSet<StageHistory> StageHistory { get; set; }

        public DbSet<User> User { get; set; }
    }
}
