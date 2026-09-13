using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfilePriceUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public decimal NewPrice { get; }

    public CPUProfilePriceUpdatedEvent(CPUProfileId profileId, decimal newPrice)
    {
        ProfileId = profileId;
        NewPrice = newPrice;
    }
}
