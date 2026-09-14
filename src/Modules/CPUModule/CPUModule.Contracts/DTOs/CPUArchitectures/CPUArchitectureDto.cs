using System;

namespace CPUModule.Contracts.DTOs.CPUArchitectures;

public record CPUArchitectureDto(
    Guid Id,
    string Name,
    int ProcessNodeNM,
    string? Description
);
