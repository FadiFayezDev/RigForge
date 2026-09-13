using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileCoresUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public int PerformanceCores { get; }
    public int EfficiencyCores { get; }
    public int TotalCores { get; }

    public CPUProfileCoresUpdatedEvent(
        CPUProfileId profileId,
        int performanceCores,
        int efficiencyCores,
        int totalCores)
    {
        ProfileId = profileId;
        PerformanceCores = performanceCores;
        EfficiencyCores = efficiencyCores;
        TotalCores = totalCores;
    }
}
