using SwiftShip.Database.Entities;

namespace SwiftShip.BusinessLogic.Utils
{
    public interface IStageHistoryInitializer
    {
        List<StageHistory> CreateInitial(string address);
    }
}
