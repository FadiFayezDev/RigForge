using BuildingBlocks.Domain.Bases;
using SocketModule.Domain.Enums;
using SocketModule.Domain.Primitives.Identifiers;
using System.Diagnostics.CodeAnalysis;

namespace SocketModule.Domain.Entities
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

            return new SocketProfile(name.Trim(), manufacturer);
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Socket name cannot be empty.",
                    nameof(name));

            Name = name.Trim();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
            => Manufacturer = manufacturer;
    }
}
