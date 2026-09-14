using System;

namespace SocketModule.Contracts.DTOs;

/// <summary>
/// DTO used to update an existing socket profile. Fields follow the same shape as RegisterSocketDto
/// but include the Id of the profile to update.
/// </summary>
public record UpdateSocketDto(
    Guid Id,
    string Name,
    string Manufacturer
);
