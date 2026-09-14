using System;

namespace MotherboardModule.Contracts.DTOs;

/// <summary>
/// Represents the data required to register a new motherboard profile.
/// </summary>
/// <param name="Name"></param>
/// <param name="Manufacturer"></param>
/// <param name="SocketId"></param>
/// <param name="RamSlots"></param>
/// <param name="RamType"></param>
/// <param name="MaxRamCapacityGB"></param>
/// <param name="PcieVersion"></param>
/// <param name="M2Slots"></param>
/// <param name="SataPorts"></param>
public record RegisterMotherboardDto(
    string Name,
    string Manufacturer,
    Guid SocketId,
    int RamSlots,
    string RamType,
    int MaxRamCapacityGB,
    string PcieVersion,
    int M2Slots,
    int SataPorts
);
