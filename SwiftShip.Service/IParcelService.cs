using SwiftShip.Database.Entities;

namespace SwiftShip.Service
{
    public interface IParcelService
    {
        Task<List<Parcel>> GetAllAsync();

        Task<Parcel?> GetAsync(string id);

        Task DeleteAsync(Parcel parcel);

        Task UpdateAsync(Parcel parcel);

        Task AddAsync(Parcel parcel);
    }
}
