using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Models;

namespace BusinessLayer.Services.Mapper
{
    public class ServiceStationProfile : Profile
    {
        public ServiceStationProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<CarTechnicalCondition, CarTechnicalConditionDTO>().ReverseMap();
            CreateMap<Inspector, InspectorDTO>().ReverseMap();
            CreateMap<Owner, OwnerDTO>().ReverseMap();
        }
    }
}
