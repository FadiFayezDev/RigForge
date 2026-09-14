using System;

namespace MotherboardModule.Contracts.DTOs;

/// <summary>
/// DTO used to update an existing chipset profile. Fields follow the same shape as RegisterChipsetDto
/// but include the Id of the profile to update.
/// </summary>
public record UpdateChipsetDto(
    Guid Id,
    string Name,
    string Manufacturer,
    Guid SocketId
);
