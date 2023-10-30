using SwiftShip.Database.Entities;

namespace SwiftShip.BusinessLogic
{
    public interface IStageHistoryInitializer
    {
        List<StageHistory> CreateInitial(string address);
    }
}
