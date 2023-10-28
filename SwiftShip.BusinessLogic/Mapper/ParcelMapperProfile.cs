using AutoMapper;
using SwiftShip.BusinessLogic.Models;
using SwiftShip.Database.Entities;
using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Mapper
{
    public class ParcelMapperProfile : Profile
    {
        public ParcelMapperProfile()
        {
            CreateMap<BaseParcelModel, Parcel>()
                .ForMember(e => e.RegisteredDate, o => o.MapFrom(s => DateTime.UtcNow))
                .ForMember(e => e.StageHistory, o => o.Ignore())
                .ForMember(e => e.Customer, o => o.MapFrom(s => s.Customer));

            CreateMap<Parcel, ParcelModel>()
               .ForMember(e => e.RegisteredDate, o => o.MapFrom(s => s.RegisteredDate))
               .ForMember(e => e.StageType, o => o.MapFrom(s => (StageType) s.StageHistory!.First().StageId))
               .ForMember(e => e.Customer, o => o.MapFrom(s => s.Customer));

            CreateMap<CustomerModel, Customer>();

            CreateMap<Customer, CustomerModel>();
        }
    }
}
