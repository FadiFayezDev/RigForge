using CPUModule.Application.Abstractions;
using CPUModule.Domain.Entities;
using CPUModule.Domain.Enums;
using CPUModule.Domain.Primitives.Identifiers;
using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CPUModule.Application.Repositories.Commands;
using SocketModule.Contracts.Services;

namespace CPUModule.Application.UseCases.CPUs
{
    /// <summary>
    /// Command to update an existing CPU profile.
    /// Only properties that have explicit domain update behaviors will be modified.
    /// </summary>
    public sealed record UpdateCpuCommand(
        CPUProfileId Id,

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
        CoolerType? IncludedCoolerType,
        bool SupportsOverclocking,

        // Integrated Graphics
        bool HasIntegratedGraphics,
        string? IntegratedGraphicsModel,

        // Compatibility
        Guid SocketId,
        RamType SupportedRamType,
        int MaxMemorySpeedMHz,
        int MaxMemoryCapacityGB,
        PCIeVersion PCIeVersion,
        int PCIeLanes

    ) : ICommand<Unit>;

    public sealed class UpdateCpuCommandHandler : IRequestHandler<UpdateCpuCommand, Unit>
    {
        private readonly ICPUProfileRepository _cpuProfileRepository;
        private readonly ISocketServices _socketServices;

        public UpdateCpuCommandHandler(ICPUProfileRepository cpuProfileRepository, ISocketServices socketServices)
        {
            _cpuProfileRepository = cpuProfileRepository;
            _socketServices = socketServices;
        }

        public async Task<Unit> Handle(UpdateCpuCommand command, CancellationToken cancellationToken)
        {
            var cpu = await _cpuProfileRepository.GetByIdAsync(command.Id);
            if (cpu is null)
                throw new ArgumentException($"CPU profile with id {command.Id} was not found.");

            // Validate the socket reference through Socket.Contracts only.
            if (!await _socketServices.SocketExistsAsync(command.SocketId))
                throw new ArgumentException($"Socket profile with id {command.SocketId} was not found.", nameof(command.SocketId));

            // Apply domain behaviors (they validate invariants and raise domain events)
            cpu.UpdateName(command.Name);
            cpu.UpdatePrice(command.Price);
            cpu.UpdateCores(command.PerformanceCores, command.EfficiencyCores);
            cpu.UpdateThreads(command.Threads);
            cpu.UpdateClockSpeeds(command.BaseClockGHz, command.BoostClockGHz);
            cpu.UpdateCache(command.L2CacheMB, command.L3CacheMB);
            cpu.UpdateCooling(command.TDPWatts, command.CoolerIncluded, command.IncludedCoolerType);
            cpu.UpdateOverclocking(command.SupportsOverclocking);
            cpu.UpdateIntegratedGraphics(command.HasIntegratedGraphics, command.IntegratedGraphicsModel);
            cpu.UpdateSocket(command.SocketId);
            cpu.UpdateMemorySupport(command.SupportedRamType, command.MaxMemorySpeedMHz, command.MaxMemoryCapacityGB);
            cpu.UpdatePCIe(command.PCIeVersion, command.PCIeLanes);

            await _cpuProfileRepository.UpdateAsync(cpu);

            return Unit.Value;
        }
    }
}
