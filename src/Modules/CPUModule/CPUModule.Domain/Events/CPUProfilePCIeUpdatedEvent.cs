using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;
using CPUModule.Domain.Enums;

namespace CPUModule.Domain.Events;

public sealed class CPUProfilePCIeUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public PCIeVersion PCIeVersion { get; }
    public int PCIeLanes { get; }

    public CPUProfilePCIeUpdatedEvent(CPUProfileId profileId, PCIeVersion pcieVersion, int pcieLanes)
    {
        ProfileId = profileId;
        PCIeVersion = pcieVersion;
        PCIeLanes = pcieLanes;
    }
}
