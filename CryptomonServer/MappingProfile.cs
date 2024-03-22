using AutoMapper;
using CryptomonServer.Dtos;
using CryptomonServer.Orm;

namespace EukaApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Monster, MonsterDto>();
            CreateMap<MonsterDto, Monster>();
            CreateMap<Cryptomon, CryptomonDto>();
            CreateMap<CryptomonDto, Cryptomon>();
            CreateMap<Land, LandDto>();
            CreateMap<LandDto, Land>();
            CreateMap<Planting, PlantingDto>();
            CreateMap<PlantingDto, Planting>();
        }
    }
}
