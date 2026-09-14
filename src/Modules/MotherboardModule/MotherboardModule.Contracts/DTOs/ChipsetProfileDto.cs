using System;

namespace MotherboardModule.Contracts.DTOs;

/// <summary>
/// Full chipset profile DTO returned to clients.
/// Enum-like values are represented as strings and Ids as GUIDs to keep the contract simple.
/// </summary>
public record ChipsetProfileDto(
    Guid Id,
    string Name,
    string Manufacturer,
    Guid SocketId
);
