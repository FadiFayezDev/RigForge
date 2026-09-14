using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileCacheUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public int L2CacheMB { get; }
    public int L3CacheMB { get; }

    public CPUProfileCacheUpdatedEvent(CPUProfileId profileId, int l2CacheMB, int l3CacheMB)
    {
        ProfileId = profileId;
        L2CacheMB = l2CacheMB;
        L3CacheMB = l3CacheMB;
    }
}
