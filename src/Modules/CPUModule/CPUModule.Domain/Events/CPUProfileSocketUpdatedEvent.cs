using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileSocketUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public Guid SocketId { get; }

    public CPUProfileSocketUpdatedEvent(CPUProfileId profileId, Guid socketId)
    {
        ProfileId = profileId;
        SocketId = socketId;
    }
}
