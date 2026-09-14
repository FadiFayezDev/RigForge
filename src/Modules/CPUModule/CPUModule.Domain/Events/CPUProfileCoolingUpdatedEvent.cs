using BuildingBlocks.Application.Primitives.Events;
using CPUModule.Domain.Primitives.Identifiers;
using CPUModule.Domain.Enums;

namespace CPUModule.Domain.Events;

public sealed class CPUProfileCoolingUpdatedEvent : DomainEvent
{
    public CPUProfileId ProfileId { get; }
    public int TDPWatts { get; }
    public bool CoolerIncluded { get; }
    public CoolerType? IncludedCoolerType { get; }

    public CPUProfileCoolingUpdatedEvent(
        CPUProfileId profileId,
        int tdpWatts,
        bool coolerIncluded,
        CoolerType? includedCoolerType)
    {
        ProfileId = profileId;
        TDPWatts = tdpWatts;
        CoolerIncluded = coolerIncluded;
        IncludedCoolerType = includedCoolerType;
    }
}
