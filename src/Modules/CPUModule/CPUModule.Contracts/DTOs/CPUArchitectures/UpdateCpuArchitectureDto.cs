using System;

namespace CPUModule.Contracts.DTOs.CPUArchitectures;

public record UpdateCpuArchitectureDto(
    Guid Id,
    string Name,
    int ProcessNodeNM,
    string? Description
);
