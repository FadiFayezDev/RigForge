using BuildingBlocks.Domain.Bases;
using CPUModule.Domain.Enums;
using CPUModule.Domain.Primitives.Identifiers;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Socket
{
    public class SocketProfile : AggregateRoot<SocketProfileId>
    {
        public string Name { get; private set; } = default!;
        public Manufacturer Manufacturer { get; private set; }

        private SocketProfile()
        {

        }

        [SetsRequiredMembers]
        private SocketProfile(string name,
            Manufacturer manufacturer)
        {
            Id = SocketProfileId.New();
            Name = name;
            Manufacturer = manufacturer;
        }

        public static SocketProfile Create(string name, Manufacturer manufacturer)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Socket name cannot be empty.",
                    nameof(name));

            return new SocketProfile(name, manufacturer);
        }

        public void UpdateName(string name)
            => Name = name;

        public void UpdateManufacturer(Manufacturer manufacturer)
            => Manufacturer = manufacturer;
    }
}