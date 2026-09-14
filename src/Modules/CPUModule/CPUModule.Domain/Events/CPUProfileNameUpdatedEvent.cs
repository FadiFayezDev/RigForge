using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileNameUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public string NewName { get; }

    public CPUProfileNameUpdatedEvent(CPUProfileId profileId, string newName)
    {
        ProfileId = profileId;
        NewName = newName;
    }
}
