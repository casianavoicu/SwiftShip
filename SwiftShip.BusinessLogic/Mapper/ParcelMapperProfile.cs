﻿using AutoMapper;
using SwiftShip.BusinessLogic.Models;
using SwiftShip.Database.Entities;
using SwiftShip.Database.Enums;

namespace SwiftShip.BusinessLogic.Mapper
{
    public class ParcelMapperProfile : Profile
    {
        public ParcelMapperProfile()
        {
            CreateMap<ParcelModel, Parcel>()
                .ForMember(e => e.StageHistory, o => o.Ignore())
                .ForMember(e => e.RegisteredDate, o => o.MapFrom(s => s.RegisteredDate))
                .ForMember(e => e.Customer, o => o.MapFrom(s => s.Customer));

            CreateMap<Parcel, ParcelModel>()
               .ForMember(e => e.RegisteredDate, o => o.MapFrom(s => s.RegisteredDate))
               .ForMember(e => e.Address, o => o.MapFrom(s => s.StageHistory.OrderByDescending(e => e.CreatedDate).First().Address))
               .ForMember(e => e.StageType, o => o.MapFrom(s => (StageType) s.StageHistory!.OrderByDescending(e => e.CreatedDate).First().StageId))
               .ForMember(e => e.Customer, o => o.MapFrom(s => s.Customer));

            CreateMap<CustomerModel, Customer>();

            CreateMap<Customer, CustomerModel>();

            CreateMap<Parcel, CustomerParcelModel>()
                .ForMember(e => e.Stages, o => o.MapFrom(s => s.StageHistory));

            CreateMap<StageHistory, BaseStageHistoryModel>()
                .ForMember(e => e.Stage, o => o.MapFrom(s => (StageType)s.StageId));

            CreateMap<ParcelStageModel, StageHistory>()
                .ForMember(e => e.ParcelId, o => o.MapFrom(s => s.Id))
                .ForMember(e => e.Id, o => o.Ignore())
                .ForMember(e => e.StageId, o => o.MapFrom(s => (int)s.Stage))
                .ForMember(e => e.Stage, o => o.Ignore());

            CreateMap<Parcel, ParcelStageModel>()
                .ForMember(e => e.Stage, o => o.MapFrom(s => (StageType)s.StageHistory.OrderByDescending(e => e.CreatedDate)!.First().StageId))
                .ForMember(e => e.Address, o => o.MapFrom(s => s.StageHistory.OrderByDescending(e => e.CreatedDate)!.First().Address));
        }
    }
}
