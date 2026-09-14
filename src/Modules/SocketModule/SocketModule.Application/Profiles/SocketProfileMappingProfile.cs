using AutoMapper;
using SocketModule.Domain.Primitives.Identifiers;

namespace SocketModule.Application.Profiles
{
    internal class SocketProfileMappingProfile : Profile
    {
        public SocketProfileMappingProfile()
        {
            CreateMap<SocketModule.Contracts.DTOs.RegisterSocketDto, SocketModule.Application.UseCases.Sockets.RegisterNewSocketCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => Enum.Parse<SocketModule.Domain.Enums.Manufacturer>(src.Manufacturer)));

            CreateMap<SocketModule.Contracts.DTOs.UpdateSocketDto, SocketModule.Application.UseCases.Sockets.UpdateSocketCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => SocketModule.Domain.Primitives.Identifiers.SocketProfileId.FromGuid(src.Id)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => Enum.Parse<SocketModule.Domain.Enums.Manufacturer>(src.Manufacturer)));

            CreateMap<SocketModule.Domain.Entities.SocketProfile, SocketModule.Contracts.DTOs.SocketProfileDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.ToString()));
        }
    }
}
