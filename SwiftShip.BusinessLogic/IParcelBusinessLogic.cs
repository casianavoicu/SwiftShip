using SwiftShip.BusinessLogic.Models;

namespace SwiftShip.BusinessLogic
{
    public interface IParcelBusinessLogic
    {
        Task<bool> AddAsync(ParcelModel parcelModel);

        Task<List<CustomerParcelModel>> GetAllAsync();

        Task<bool> UpdateAsync(ParcelModel parcelModel);

        Task<CustomerParcelModel> GetAsync(string id);
    }
}
