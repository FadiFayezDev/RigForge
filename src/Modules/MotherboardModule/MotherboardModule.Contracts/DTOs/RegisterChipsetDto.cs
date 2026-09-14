using System;

namespace MotherboardModule.Contracts.DTOs;

/// <summary>
/// Represents the data required to register a new chipset profile.
/// </summary>
/// <param name="Name"></param>
/// <param name="Manufacturer"></param>
/// <param name="SocketId"></param>
public record RegisterChipsetDto(
    string Name,
    string Manufacturer,
    Guid SocketId
);
