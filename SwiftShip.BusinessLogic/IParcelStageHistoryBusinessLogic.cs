using SwiftShip.BusinessLogic.Models;

namespace SwiftShip.BusinessLogic
{
    public interface IParcelStageHistoryBusinessLogic
    {
        Task<bool> AddAsync(ParcelStageModel parcelStageModel);
        Task<List<ParcelStageModel>> GetAllAsync();
    }
}
