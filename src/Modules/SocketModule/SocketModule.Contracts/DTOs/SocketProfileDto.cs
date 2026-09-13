using System;

namespace SocketModule.Contracts.DTOs;

/// <summary>
/// Full socket profile DTO returned to clients.
/// Enum-like values are represented as strings and Ids as GUIDs to keep the contract simple.
/// </summary>
public record SocketProfileDto(
    Guid Id,
    string Name,
    string Manufacturer
);
