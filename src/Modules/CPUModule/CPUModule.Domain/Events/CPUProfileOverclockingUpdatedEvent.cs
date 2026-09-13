using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileOverclockingUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public bool SupportsOverclocking { get; }

    public CPUProfileOverclockingUpdatedEvent(CPUProfileId profileId, bool supportsOverclocking)
    {
        ProfileId = profileId;
        SupportsOverclocking = supportsOverclocking;
    }
}
