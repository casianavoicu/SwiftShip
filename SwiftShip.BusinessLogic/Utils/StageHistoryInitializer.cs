using SwiftShip.Database.Entities;
using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Utils
{
    sealed internal class StageHistoryInitializer : IStageHistoryInitializer
    {
        public List<StageHistory> CreateInitial(string address)
        {
            return new List<StageHistory>
            {
                new StageHistory
                {
                    Address =  address,
                    StageId = (int)StageType.Warehouse,
                    CreatedDate = DateTime.UtcNow,
                }
            };
        }
    }
}
