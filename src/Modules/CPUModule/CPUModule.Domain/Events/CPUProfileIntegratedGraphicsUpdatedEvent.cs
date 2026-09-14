using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileIntegratedGraphicsUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public bool HasIntegratedGraphics { get; }
    public string? IntegratedGraphicsModel { get; }

    public CPUProfileIntegratedGraphicsUpdatedEvent(
        CPUProfileId profileId,
        bool hasIntegratedGraphics,
        string? integratedGraphicsModel)
    {
        ProfileId = profileId;
        HasIntegratedGraphics = hasIntegratedGraphics;
        IntegratedGraphicsModel = integratedGraphicsModel;
    }
}
