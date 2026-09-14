using AutoMapper;

namespace MotherboardModule.Application.Profiles
{
    internal class MotherboardProfileMappingProfile : Profile
    {
        public MotherboardProfileMappingProfile()
        {
            CreateMap<MotherboardModule.Contracts.DTOs.RegisterMotherboardDto, MotherboardModule.Application.UseCases.Motherboards.RegisterNewMotherboardCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => Enum.Parse<MotherboardModule.Domain.Enums.Manufacturer>(src.Manufacturer)))
                .ForMember(dest => dest.SocketId, opt => opt.MapFrom(src => src.SocketId))
                .ForMember(dest => dest.RamSlots, opt => opt.MapFrom(src => src.RamSlots))
                .ForMember(dest => dest.RamType, opt => opt.MapFrom(src => Enum.Parse<MotherboardModule.Domain.Enums.RamType>(src.RamType)))
                .ForMember(dest => dest.MaxRamCapacityGB, opt => opt.MapFrom(src => src.MaxRamCapacityGB))
                .ForMember(dest => dest.PcieVersion, opt => opt.MapFrom(src => Enum.Parse<MotherboardModule.Domain.Enums.PCIeVersion>(src.PcieVersion)))
                .ForMember(dest => dest.M2Slots, opt => opt.MapFrom(src => src.M2Slots))
                .ForMember(dest => dest.SataPorts, opt => opt.MapFrom(src => src.SataPorts));

            CreateMap<MotherboardModule.Domain.Entities.MotherboardProfile, MotherboardModule.Contracts.DTOs.MotherboardProfileDto>()
                // Record constructor parameter needs an explicit mapping:
                // the source Id is a strongly-typed ID struct, not a Guid.
                .ForCtorParam(nameof(MotherboardModule.Contracts.DTOs.MotherboardProfileDto.Id), opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.ToString()))
                .ForMember(dest => dest.SocketId, opt => opt.MapFrom(src => src.SocketId))
                .ForMember(dest => dest.RamSlots, opt => opt.MapFrom(src => src.RamSlots))
                .ForMember(dest => dest.RamType, opt => opt.MapFrom(src => src.RamType.ToString()))
                .ForMember(dest => dest.MaxRamCapacityGB, opt => opt.MapFrom(src => src.MaxRamCapacityGB))
                .ForMember(dest => dest.PcieVersion, opt => opt.MapFrom(src => src.PcieVersion.ToString()))
                .ForMember(dest => dest.M2Slots, opt => opt.MapFrom(src => src.M2Slots))
                .ForMember(dest => dest.SataPorts, opt => opt.MapFrom(src => src.SataPorts));

            CreateMap<MotherboardModule.Contracts.DTOs.RegisterChipsetDto, MotherboardModule.Application.UseCases.Chipsets.RegisterNewChipsetCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => Enum.Parse<MotherboardModule.Domain.Enums.ChipsetManufacturer>(src.Manufacturer)))
                .ForMember(dest => dest.SocketId, opt => opt.MapFrom(src => src.SocketId));

            CreateMap<MotherboardModule.Contracts.DTOs.UpdateChipsetDto, MotherboardModule.Application.UseCases.Chipsets.UpdateChipsetCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => MotherboardModule.Domain.Primitives.Identifiers.ChipsetProfileId.FromGuid(src.Id)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => Enum.Parse<MotherboardModule.Domain.Enums.ChipsetManufacturer>(src.Manufacturer)))
                .ForMember(dest => dest.SocketId, opt => opt.MapFrom(src => src.SocketId));

            CreateMap<MotherboardModule.Domain.Entities.ChipsetProfile, MotherboardModule.Contracts.DTOs.ChipsetProfileDto>()
                // Record constructor parameter needs an explicit mapping:
                // the source Id is a strongly-typed ID struct, not a Guid.
                .ForCtorParam(nameof(MotherboardModule.Contracts.DTOs.ChipsetProfileDto.Id), opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.ToString()))
                .ForMember(dest => dest.SocketId, opt => opt.MapFrom(src => src.SocketId));
        }
    }
}
