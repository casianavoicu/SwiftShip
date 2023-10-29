using SwiftShip.Database.Entities;

namespace SwiftShip.Service
{
    public interface IStageService
    {
        Task AddStage(StageHistory stageHistory);

        Task UpdateAsync(StageHistory stageHistory);
    }
}
