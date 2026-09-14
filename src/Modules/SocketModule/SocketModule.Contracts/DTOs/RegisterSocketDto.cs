namespace SocketModule.Contracts.DTOs;

/// <summary>
/// Represents the data required to register a new socket profile.
/// </summary>
/// <param name="Name"></param>
/// <param name="Manufacturer"></param>
public record RegisterSocketDto(
    string Name,
    string Manufacturer
);
