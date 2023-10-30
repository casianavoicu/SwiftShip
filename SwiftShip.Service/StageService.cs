using SwiftShip.Database;
using SwiftShip.Database.Entities;

namespace SwiftShip.Service
{
    sealed internal class StageService : IStageService
    {
        private readonly SwiftShipDbContext _dbContext;

        public StageService(SwiftShipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddStage(StageHistory stageHistory)
        {
            _dbContext.StageHistory.Add(stageHistory);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StageHistory stageHistory)
        {
            _dbContext.StageHistory.Update(stageHistory);

            await _dbContext.SaveChangesAsync();
        }
    }
}
