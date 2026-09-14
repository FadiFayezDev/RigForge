using AutoMapper;
using CPUModule.Domain.Primitives.Identifiers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CPUModule.Application.Profiles
{
    internal class CpuProfileMappingProfile : Profile
    {
        public CpuProfileMappingProfile() 
        {
            CreateMap<CPUModule.Contracts.DTOs.CPU.RegisterCpuDto, CPUModule.Application.UseCases.CPUs.RegisterNewCpuCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => Enum.Parse<CPUModule.Domain.Enums.Manufacturer>(src.Manufacturer)))
                .ForMember(dest => dest.Family, opt => opt.MapFrom(src => Enum.Parse<CPUModule.Domain.Enums.CPUFamily>(src.Family)))
                .ForMember(dest => dest.ArchitectureId, opt => opt.MapFrom(src => CPUArchitectureId.FromGuid(src.ArchitectureId)))
                .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
                .ForMember(dest => dest.PerformanceCores, opt => opt.MapFrom(src => src.PerformanceCores))
                .ForMember(dest => dest.EfficiencyCores, opt => opt.MapFrom(src => src.EfficiencyCores))
                .ForMember(dest => dest.Threads, opt => opt.MapFrom(src => src.Threads))
                .ForMember(dest => dest.BaseClockGHz, opt => opt.MapFrom(src => src.BaseClockGHz))
                .ForMember(dest => dest.BoostClockGHz, opt => opt.MapFrom(src => src.BoostClockGHz))
                .ForMember(dest => dest.L2CacheMB, opt => opt.MapFrom(src => src.L2CacheMB))
                .ForMember(dest => dest.L3CacheMB, opt => opt.MapFrom(src => src.L3CacheMB))
                .ForMember(dest => dest.TDPWatts, opt => opt.MapFrom(src => src.TDPWatts))
                .ForMember(dest => dest.CoolerIncluded, opt => opt.MapFrom(src => src.CoolerIncluded))
                .ForMember(dest => dest.SupportsOverclocking, opt => opt.MapFrom(src => src.SupportsOverclocking))
                .ForMember(dest => dest.HasIntegratedGraphics, opt => opt.MapFrom(src => src.HasIntegratedGraphics))
                .ForMember(dest => dest.IntegratedGraphicsModel, opt => opt.MapFrom(src => src.IntegratedGraphicsModel))
                .ForMember(dest => dest.SocketId, opt => opt.MapFrom(src => src.SocketId))
                .ForMember(dest => dest.SupportedRamType, opt => opt.MapFrom(src => Enum.Parse<CPUModule.Domain.Enums.RamType>(src.SupportedRamType)))
                .ForMember(dest => dest.MaxMemorySpeedMHz, opt => opt.MapFrom(src => src.MaxMemorySpeedMHz))
                .ForMember(dest => dest.MaxMemoryCapacityGB, opt => opt.MapFrom(src => src.MaxMemoryCapacityGB))
                .ForMember(dest => dest.PCIeVersion, opt => opt.MapFrom(src => Enum.Parse<CPUModule.Domain.Enums.PCIeVersion>(src.PCIeVersion)))
                .ForMember(dest => dest.PCIeLanes, opt => opt.MapFrom(src => src.PCIeLanes))
                .ForMember(dest => dest.IncludedCoolerType, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.IncludedCoolerType) ? (CPUModule.Domain.Enums.CoolerType?)null : Enum.Parse<CPUModule.Domain.Enums.CoolerType>(src.IncludedCoolerType)));

            CreateMap<CPUModule.Contracts.DTOs.CPU.UpdateCpuDto, CPUModule.Application.UseCases.CPUs.UpdateCpuCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => CPUModule.Domain.Primitives.Identifiers.CPUProfileId.FromGuid(src.Id)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.PerformanceCores, opt => opt.MapFrom(src => src.PerformanceCores))
                .ForMember(dest => dest.EfficiencyCores, opt => opt.MapFrom(src => src.EfficiencyCores))
                .ForMember(dest => dest.Threads, opt => opt.MapFrom(src => src.Threads))
                .ForMember(dest => dest.BaseClockGHz, opt => opt.MapFrom(src => src.BaseClockGHz))
                .ForMember(dest => dest.BoostClockGHz, opt => opt.MapFrom(src => src.BoostClockGHz))
                .ForMember(dest => dest.L2CacheMB, opt => opt.MapFrom(src => src.L2CacheMB))
                .ForMember(dest => dest.L3CacheMB, opt => opt.MapFrom(src => src.L3CacheMB))
                .ForMember(dest => dest.TDPWatts, opt => opt.MapFrom(src => src.TDPWatts))
                .ForMember(dest => dest.CoolerIncluded, opt => opt.MapFrom(src => src.CoolerIncluded))
                .ForMember(dest => dest.IncludedCoolerType, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.IncludedCoolerType) ? (CPUModule.Domain.Enums.CoolerType?)null : Enum.Parse<CPUModule.Domain.Enums.CoolerType>(src.IncludedCoolerType)))
                .ForMember(dest => dest.SupportsOverclocking, opt => opt.MapFrom(src => src.SupportsOverclocking))
                .ForMember(dest => dest.HasIntegratedGraphics, opt => opt.MapFrom(src => src.HasIntegratedGraphics))
                .ForMember(dest => dest.IntegratedGraphicsModel, opt => opt.MapFrom(src => src.IntegratedGraphicsModel))
                .ForMember(dest => dest.SocketId, opt => opt.MapFrom(src => src.SocketId))
                .ForMember(dest => dest.SupportedRamType, opt => opt.MapFrom(src => Enum.Parse<CPUModule.Domain.Enums.RamType>(src.SupportedRamType)))
                .ForMember(dest => dest.MaxMemorySpeedMHz, opt => opt.MapFrom(src => src.MaxMemorySpeedMHz))
                .ForMember(dest => dest.MaxMemoryCapacityGB, opt => opt.MapFrom(src => src.MaxMemoryCapacityGB))
                .ForMember(dest => dest.PCIeVersion, opt => opt.MapFrom(src => Enum.Parse<CPUModule.Domain.Enums.PCIeVersion>(src.PCIeVersion)))
                .ForMember(dest => dest.PCIeLanes, opt => opt.MapFrom(src => src.PCIeLanes));

            CreateMap<CPUModule.Domain.Entities.CPUProfile, CPUModule.Contracts.DTOs.CPU.CPUProfileDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer.ToString()))
                .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Family.ToString()))
                .ForMember(dest => dest.ArchitectureId, opt => opt.MapFrom(src => src.ArchitectureId.Value))
                .ForMember(dest => dest.ReleaseYear, opt => opt.MapFrom(src => src.ReleaseYear))
                .ForMember(dest => dest.PerformanceCores, opt => opt.MapFrom(src => src.Cores.PerformanceCores))
                .ForMember(dest => dest.EfficiencyCores, opt => opt.MapFrom(src => src.Cores.EfficiencyCores))
                .ForMember(dest => dest.Threads, opt => opt.MapFrom(src => src.Threads))
                .ForMember(dest => dest.BaseClockGHz, opt => opt.MapFrom(src => src.BaseClockGHz))
                .ForMember(dest => dest.BoostClockGHz, opt => opt.MapFrom(src => src.BoostClockGHz))
                .ForMember(dest => dest.L2CacheMB, opt => opt.MapFrom(src => src.L2CacheMB))
                .ForMember(dest => dest.L3CacheMB, opt => opt.MapFrom(src => src.L3CacheMB))
                .ForMember(dest => dest.TDPWatts, opt => opt.MapFrom(src => src.TDPWatts))
                .ForMember(dest => dest.CoolerIncluded, opt => opt.MapFrom(src => src.CoolerIncluded))
                .ForMember(dest => dest.IncludedCoolerType, opt => opt.MapFrom(src => src.IncludedCoolerType.HasValue ? src.IncludedCoolerType.Value.ToString() : null))
                .ForMember(dest => dest.SupportsOverclocking, opt => opt.MapFrom(src => src.SupportsOverclocking))
                .ForMember(dest => dest.HasIntegratedGraphics, opt => opt.MapFrom(src => src.HasIntegratedGraphics))
                .ForMember(dest => dest.IntegratedGraphicsModel, opt => opt.MapFrom(src => src.IntegratedGraphicsModel))
                .ForMember(dest => dest.SocketId, opt => opt.MapFrom(src => src.SocketId))
                .ForMember(dest => dest.SupportedRamType, opt => opt.MapFrom(src => src.SupportedRamType.ToString()))
                .ForMember(dest => dest.MaxMemorySpeedMHz, opt => opt.MapFrom(src => src.MaxMemorySpeedMHz))
                .ForMember(dest => dest.MaxMemoryCapacityGB, opt => opt.MapFrom(src => src.MaxMemoryCapacityGB))
                .ForMember(dest => dest.PCIeVersion, opt => opt.MapFrom(src => src.PCIeVersion.ToString()))
                .ForMember(dest => dest.PCIeLanes, opt => opt.MapFrom(src => src.PCIeLanes));

            CreateMap<CPUModule.Domain.Entities.CPUProfile, CPUModule.Contracts.DTOs.CPU.CPUMiniProfileDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Cores, opt => opt.MapFrom(src => src.Cores.TotalCores))
                .ForMember(dest => dest.Threads, opt => opt.MapFrom(src => src.Threads))
                .ForMember(dest => dest.BaseClockGHz, opt => opt.MapFrom(src => src.BaseClockGHz))
                .ForMember(dest => dest.BoostClockGHz, opt => opt.MapFrom(src => src.BoostClockGHz))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            // CPU Architecture mapping
            CreateMap<global::Domain.Entities.CPU.CPUArchitecture, CPUModule.Contracts.DTOs.CPUArchitectures.CPUArchitectureDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProcessNodeNM, opt => opt.MapFrom(src => src.ProcessNodeNM))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<CPUModule.Contracts.DTOs.CPUArchitectures.RegisterCpuArchitectureDto, CPUModule.Application.UseCases.CPUArchitectures.RegisterNewCpuArchitectureCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProcessNodeNM, opt => opt.MapFrom(src => src.ProcessNodeNM))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<CPUModule.Contracts.DTOs.CPUArchitectures.UpdateCpuArchitectureDto, CPUModule.Application.UseCases.CPUArchitectures.UpdateCpuArchitectureCommand>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => CPUModule.Domain.Primitives.Identifiers.CPUArchitectureId.FromGuid(src.Id)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProcessNodeNM, opt => opt.MapFrom(src => src.ProcessNodeNM))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));


        }
    }
}
