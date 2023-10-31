
using Microsoft.EntityFrameworkCore;
using SwiftShip.Database;
using SwiftShip.Database.Entities;
using System.Linq.Expressions;

namespace SwiftShip.Service
{
    sealed internal class ParcelService : IParcelService
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

        public async Task RemoveAsync(Parcel parcel)
        {
            _dbContext.Customer.Remove(parcel.Customer);

            _dbContext.Parcel.Remove(parcel);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _dbContext.Parcel
                .Include(e => e.Customer)
                .Include(e => e.StageHistory)
                    .ThenInclude(e => e.Stage)
                .Where(e => e.StageHistory.Any())
                .ToListAsync();
        }

        public async Task<Parcel?> GetBaseAsync(int id)
        {
            return await _dbContext.Parcel.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Parcel?> GetOrderedAsync(Expression<Func<Parcel, bool>> expression)
        {
            return await _dbContext.Parcel
                .Include(e => e.Customer)
                .Include(e => e.StageHistory)
                    .ThenInclude(e => e.Stage)
                .Where(e => e.StageHistory.Any())
                .OrderByDescending(e => e.StageHistory.Max(sh => sh.CreatedDate))
                .FirstOrDefaultAsync(expression);
        }

        public async Task<Parcel?> GetExtendedAsync(int id)
        {
            return await _dbContext.Parcel
                .Include(e => e.StageHistory)
                 .ThenInclude(e => e.Stage)
                .OrderByDescending(e => e.StageHistory.Max(sh => sh.CreatedDate))
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            _dbContext.Parcel.Update(parcel);
            await _dbContext.SaveChangesAsync();
        }
    }
}
