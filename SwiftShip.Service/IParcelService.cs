﻿using SwiftShip.Database.Entities;
using System.Linq.Expressions;

namespace SwiftShip.Service
{
    public interface IParcelService
    {
        Task<List<Parcel>> GetAllAsync();

        Task<Parcel?> GetOrderedAsync(Expression<Func<Parcel, bool>> expression);

        Task RemoveAsync(Parcel parcel);

        Task UpdateAsync(Parcel parcel);

        Task AddAsync(Parcel parcel);

        Task<Parcel?> GetExtendedAsync(int id);

        Task<Parcel?> GetBaseAsync(int id);
    }
}
