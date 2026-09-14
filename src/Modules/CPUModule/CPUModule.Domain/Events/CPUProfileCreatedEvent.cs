using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileCreatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public string Name { get; }

    public CPUProfileCreatedEvent(CPUProfileId profileId, string name)
    {
        ProfileId = profileId;
        Name = name;
    }
}
