using System;

namespace CPUModule.Contracts.DTOs.CPU;

/// <summary>
/// DTO used to update an existing CPU profile. Fields follow the same shape as RegisterCpuDto
/// but include the Id of the profile to update.
/// </summary>
public record UpdateCpuDto(
    Guid Id,

    // Identity-ish
    string Name,
    decimal Price,

    // Performance
    int PerformanceCores,
    int EfficiencyCores,
    int Threads,
    decimal BaseClockGHz,
    decimal BoostClockGHz,

    // Cache
    int L2CacheMB,
    int L3CacheMB,

    // Power & Cooling
    int TDPWatts,
    bool CoolerIncluded,
    string? IncludedCoolerType,
    bool SupportsOverclocking,

    // Integrated Graphics
    bool HasIntegratedGraphics,
    string? IntegratedGraphicsModel,

    // Compatibility
    Guid SocketId,
    string SupportedRamType,
    int MaxMemorySpeedMHz,
    int MaxMemoryCapacityGB,
    string PCIeVersion,
    int PCIeLanes
);

