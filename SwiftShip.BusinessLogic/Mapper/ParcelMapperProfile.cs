using AutoMapper;
using SwiftShip.BusinessLogic.Models;
using SwiftShip.Database.Entities;

namespace SwiftShip.BusinessLogic.Mapper
{
    public class ParcelMapperProfile : Profile
    {
        public ParcelMapperProfile()
        {
            CreateMap<Parcel, ParcelModel>();

            CreateMap<ParcelModel, Parcel>();
        }
    }
}
