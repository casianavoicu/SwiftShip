using SwiftShip.BusinessLogic.Models;

namespace SwiftShip.BusinessLogic.BusinessLogic
{
    public interface IParcelBusinessLogic
    {
        Task<bool> AddAsync(ParcelModel parcelModel);

        Task<List<ParcelModel>> GetAllAsync();

        Task<bool> UpdateAsync(ParcelModel parcelModel);

        Task<CustomerParcelModel> GetAsync(Guid guid);

        Task<bool> RemoveAsync(int? id);
        Task<List<ParcelStageModel>> GetAllWithStageAsync();
    }
}
