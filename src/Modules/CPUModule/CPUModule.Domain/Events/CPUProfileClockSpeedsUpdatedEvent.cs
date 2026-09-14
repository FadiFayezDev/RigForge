using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileClockSpeedsUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public decimal BaseClockGHz { get; }
    public decimal BoostClockGHz { get; }

    public CPUProfileClockSpeedsUpdatedEvent(
        CPUProfileId profileId,
        decimal baseClockGHz,
        decimal boostClockGHz)
    {
        ProfileId = profileId;
        BaseClockGHz = baseClockGHz;
        BoostClockGHz = boostClockGHz;
    }
}
