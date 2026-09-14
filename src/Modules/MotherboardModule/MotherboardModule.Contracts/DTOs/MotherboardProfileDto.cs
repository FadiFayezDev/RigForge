using System;

namespace MotherboardModule.Contracts.DTOs;

/// <summary>
/// Full motherboard profile DTO returned to clients.
/// Enum-like values are represented as strings and Ids as GUIDs to keep the contract simple.
/// </summary>
public record MotherboardProfileDto(
    Guid Id,
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
