using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileThreadsUpdatedEvent : DomainEvent
{
    public CPUProfileThreadsUpdatedEvent(CPUProfileId profileId, int threads)
    {
        ProfileId = profileId;
        Threads = threads;
    }

    public CPUProfileId ProfileId { get; }
    public int Threads { get; }
}
