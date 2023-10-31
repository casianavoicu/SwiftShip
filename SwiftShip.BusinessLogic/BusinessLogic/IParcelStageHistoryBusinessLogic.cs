using SwiftShip.BusinessLogic.Models;

namespace SwiftShip.BusinessLogic.BusinessLogic
{
    public interface IParcelStageHistoryBusinessLogic
    {
        Task<bool> AddAsync(ParcelStageModel parcelStageModel);
    }
}
