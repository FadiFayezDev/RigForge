using CPUModule.Contracts.DTOs.CPU;
using CPUModule.Domain.Enums;
using CPUModule.Domain.Primitives.Identifiers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CPUModule.Application.UseCases.CPUs
{
    public sealed record CreateCPUProfileCommand(
        // =========================
        // Identity
        // =========================

        string Name,
        decimal Price,
        Manufacturer Manufacturer,
        CPUFamily Family,
        CPUArchitectureId ArchitectureId,
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
        CoolerType? IncludedCoolerType,
        bool SupportsOverclocking,

        // =========================
        // Integrated Graphics
        // =========================

        bool HasIntegratedGraphics,
        string? IntegratedGraphicsModel,

        // =========================
        // Compatibility
        // =========================

        SocketProfileId SocketId,
        RamType SupportedRamType,
        int MaxMemorySpeedMHz,
        int MaxMemoryCapacityGB,
        PCIeVersion PCIeVersion,
        int PCIeLanes

    ) : Icomma<CPUProfileId>;
}
