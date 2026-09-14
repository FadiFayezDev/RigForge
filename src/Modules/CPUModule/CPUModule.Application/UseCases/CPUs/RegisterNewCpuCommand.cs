using CPUModule.Application.Abstractions;
using CPUModule.Application.Repositories.Commands;
using CPUModule.Domain.Entities;
using CPUModule.Domain.Enums;
using CPUModule.Domain.Primitives.Identifiers;
using MediatR;
using SocketModule.Contracts.Services;

namespace CPUModule.Application.UseCases.CPUs
{
    /// <summary>
    /// Command to register a new CPU profile in the system.
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
    /// <returns><see cref="CPUProfileId">CPU Profile Id</see></returns>
    public sealed record RegisterNewCpuCommand(
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

        Guid SocketId,
        RamType SupportedRamType,
        int MaxMemorySpeedMHz,
        int MaxMemoryCapacityGB,
        PCIeVersion PCIeVersion,
        int PCIeLanes

    ) : ICommand<CPUProfileId>;

    public sealed class RegisterNewCpuCommandHandler : IRequestHandler<RegisterNewCpuCommand, CPUProfileId>
    {
        private readonly ICPUProfileRepository _cpuProfileRepository;
        private readonly ISocketServices _socketServices;
        public RegisterNewCpuCommandHandler(ICPUProfileRepository cpuProfileRepository, ISocketServices socketServices)
        {
            _cpuProfileRepository = cpuProfileRepository;
            _socketServices = socketServices;
        }
        public async Task<CPUProfileId> Handle(RegisterNewCpuCommand command, CancellationToken cancellationToken)
        {
            // Validate the socket reference through Socket.Contracts only.
            // The CPU Module never touches Socket Domain/Infrastructure types.
            if (!await _socketServices.SocketExistsAsync(command.SocketId))
                throw new ArgumentException($"Socket profile with id {command.SocketId} was not found.", nameof(command.SocketId));

            var cpuProfile = CPUProfile.Create(
                command.Name,
                command.Price,
                command.Manufacturer,
                command.Family,
                command.ArchitectureId,
                command.ReleaseYear,
                command.PerformanceCores,
                command.EfficiencyCores,
                command.Threads,
                command.BaseClockGHz,
                command.BoostClockGHz,
                command.L2CacheMB,
                command.L3CacheMB,
                command.TDPWatts,
                command.CoolerIncluded,
                command.IncludedCoolerType,
                command.SupportsOverclocking,
                command.HasIntegratedGraphics,
                command.IntegratedGraphicsModel,
                command.SocketId,
                command.SupportedRamType,
                command.MaxMemorySpeedMHz,
                command.MaxMemoryCapacityGB,
                command.PCIeVersion,
                command.PCIeLanes
            );
            await _cpuProfileRepository.AddAsync(cpuProfile);
            return cpuProfile.Id;
        }
    }
}