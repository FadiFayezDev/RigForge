using System;
using System.Collections.Generic;
using System.Text;

namespace CPUModule.Contracts.DTOs.CPU;

/// <summary>
/// Represents the data required to register a new CPU profile.
/// </summary>
/// <param name="Name"></param>
/// <param name="Price"></param>
/// <param name="Manufacturer"></param>
/// <param name="Family"></param>
/// <param name="ArchitectureId"></param>
/// <param name="ReleaseYear"></param>
/// <param name="PerformanceCores"></param>
/// <param name="EfficiencyCores"></param>
/// <param name="Threads"></param>
/// <param name="BaseClockGHz"></param>
/// <param name="BoostClockGHz"></param>
/// <param name="L2CacheMB"></param>
/// <param name="L3CacheMB"></param>
/// <param name="TDPWatts"></param>
/// <param name="CoolerIncluded"></param>
/// <param name="IncludedCoolerType"></param>
/// <param name="SupportsOverclocking"></param>
/// <param name="HasIntegratedGraphics"></param>
/// <param name="IntegratedGraphicsModel"></param>
/// <param name="SocketId"></param>
/// <param name="SupportedRamType"></param>
/// <param name="MaxMemorySpeedMHz"></param>
/// <param name="MaxMemoryCapacityGB"></param>
/// <param name="PCIeVersion"></param>
/// <param name="PCIeLanes"></param>
public record RegisterCpuDto
(
    // =========================
    // Identity
    // =========================

    string Name,
    decimal Price,
    string Manufacturer,
    string Family,
    Guid ArchitectureId,
    int ReleaseYear,

    // =========================
    // Performance
    // =========================

    int PerformanceCores,
    int EfficiencyCores,
    int Threads,
    decimal BaseClockGHz,
    decimal BoostClockGHz,

    // =========================
    // Cache
    // =========================

    int L2CacheMB,
    int L3CacheMB,

    // =========================
    // Power & Cooling
    // =========================

    int TDPWatts,
    bool CoolerIncluded,
    string? IncludedCoolerType,
    bool SupportsOverclocking,

    // =========================
    // Integrated Graphics
    // =========================

    bool HasIntegratedGraphics,
    string? IntegratedGraphicsModel,

    // =========================
    // Compatibility
    // =========================

    Guid SocketId,
    string SupportedRamType,
    int MaxMemorySpeedMHz,
    int MaxMemoryCapacityGB,
    string PCIeVersion,
    int PCIeLanes

);