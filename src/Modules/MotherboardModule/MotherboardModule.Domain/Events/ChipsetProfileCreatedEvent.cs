using BuildingBlocks.Application.Primitives.Events;
using MotherboardModule.Domain.Primitives.Identifiers;

namespace MotherboardModule.Domain.Events;

public sealed class ChipsetProfileCreatedEvent : DomainEvent
{
    public ChipsetProfileId ProfileId { get; }
    public string Name { get; }

    public ChipsetProfileCreatedEvent(ChipsetProfileId profileId, string name)
    {
        ProfileId = profileId;
        Name = name;
    }
}
