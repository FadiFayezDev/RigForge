using BuildingBlocks.Domain.Bases;
using CPUModule.Domain.Primitives.Identifiers;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.CPU
{
    public class CPUArchitecture : AggregateRoot<CPUArchitectureId>
    {
        public string Name { get; private set; } = default!;

        public int ProcessNodeNM { get; private set; }

        public string? Description { get; private set; }

        // Private constructor for EF Core
        private CPUArchitecture()
        {
        }

        [SetsRequiredMembers]
        private CPUArchitecture(
            CPUArchitectureId id,
            string name,
            int processNodeNM,
            string? description)
        {
            Id = id;
            Name = name;
            ProcessNodeNM = processNodeNM;
            Description = description;
        }


        public static CPUArchitecture Create(
            string name,
            int processNodeNM,
            string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Architecture name cannot be empty.",
                    nameof(name));

            if (processNodeNM <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(processNodeNM));

            return new CPUArchitecture(
                CPUArchitectureId.New(),
                name.Trim(),
                processNodeNM,
                description?.Trim());
        }


        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Architecture name cannot be empty.",
                    nameof(name));

            Name = name.Trim();
        }


        public void UpdateProcessNode(int processNodeNM)
        {
            if (processNodeNM <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(processNodeNM));

            ProcessNodeNM = processNodeNM;
        }


        public void UpdateDescription(string? description)
        {
            Description = description?.Trim();
        }
    }
}
