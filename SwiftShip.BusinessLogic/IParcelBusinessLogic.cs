using SwiftShip.BusinessLogic.Models;

namespace SwiftShip.BusinessLogic
{
    public interface IParcelBusinessLogic
    {
        Task<bool> AddAsync(BaseParcelModel parcelModel);

        Task<List<ParcelModel>> GetAllAsync();

        Task<bool> UpdateAsync(BaseParcelModel parcelModel);

        Task<CustomerParcelModel> GetAsync(Guid guid);

        Task<List<CustomerModel>> GetByIdentifier(Guid guid);
    }
}
