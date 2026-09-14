using System;

namespace CPUModule.Contracts.DTOs.CPU;

/// <summary>
/// Full CPU profile DTO returned to clients.
/// Enum-like values are represented as strings and Ids as GUIDs to keep the contract simple.
/// </summary>
public record CPUProfileDto
(
    Guid Id,
    string Name,
    decimal Price,
    string Manufacturer,
    string Family,
    Guid ArchitectureId,
    int ReleaseYear,

    int PerformanceCores,
    int EfficiencyCores,
    int Threads,
    decimal BaseClockGHz,
    decimal BoostClockGHz,

    int L2CacheMB,
    int L3CacheMB,

    int TDPWatts,
    bool CoolerIncluded,
    string? IncludedCoolerType,
    bool SupportsOverclocking,

    bool HasIntegratedGraphics,
    string? IntegratedGraphicsModel,

    Guid SocketId,
    string SupportedRamType,
    int MaxMemorySpeedMHz,
    int MaxMemoryCapacityGB,
    string PCIeVersion,
    int PCIeLanes
);

