using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;
using CPUModule.Domain.Enums;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileMemorySupportUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public RamType SupportedRamType { get; }
    public int MaxMemorySpeedMHz { get; }
    public int MaxMemoryCapacityGB { get; }

    public CPUProfileMemorySupportUpdatedEvent(
        CPUProfileId profileId,
        RamType supportedRamType,
        int maxMemorySpeedMHz,
        int maxMemoryCapacityGB)
    {
        ProfileId = profileId;
        SupportedRamType = supportedRamType;
        MaxMemorySpeedMHz = maxMemorySpeedMHz;
        MaxMemoryCapacityGB = maxMemoryCapacityGB;
    }
}
