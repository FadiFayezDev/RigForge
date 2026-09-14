using BuildingBlocks.Application.Primitives.Events;
using MotherboardModule.Domain.Primitives.Identifiers;

namespace MotherboardModule.Domain.Events;

public sealed class MotherboardProfileCreatedEvent : DomainEvent
{
    public MotherboardProfileId ProfileId { get; }
    public string Name { get; }

    public MotherboardProfileCreatedEvent(MotherboardProfileId profileId, string name)
    {
        ProfileId = profileId;
        Name = name;
    }
}
