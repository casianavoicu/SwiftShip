using Microsoft.EntityFrameworkCore;
using SwiftShip.Database;
using SwiftShip.Database.Entities;

namespace SwiftShip.Service
{
    internal class ParcelService : IParcelService
    {
        private readonly SwiftShipDbContext _dbContext;

        public ParcelService(SwiftShipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Parcel parcel)
        {
            _dbContext.Parcel.Add(parcel);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Parcel parcel)
        {
            _dbContext.Parcel.Remove(parcel);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _dbContext.Parcel.ToListAsync();
        }

        public async Task<Parcel?> GetAsync(string id)
        {
            return await _dbContext.Parcel.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            _dbContext.Parcel.Update(parcel);

            await _dbContext.SaveChangesAsync();
        }
    }
}
