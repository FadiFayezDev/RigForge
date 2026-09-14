using System;

namespace CPUModule.Contracts.DTOs.CPUArchitectures;

public record RegisterCpuArchitectureDto(
    string Name,
    int ProcessNodeNM,
    string? Description
);
