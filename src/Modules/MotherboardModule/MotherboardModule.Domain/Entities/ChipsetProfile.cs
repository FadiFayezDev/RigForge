using BuildingBlocks.Domain.Bases;
using MotherboardModule.Domain.Enums;
using MotherboardModule.Domain.Events;
using MotherboardModule.Domain.Primitives.Identifiers;

namespace MotherboardModule.Domain.Entities
{
    public class ChipsetProfile : AggregateRoot<ChipsetProfileId>
    {
        public string Name { get; private set; } = default!;
        public ChipsetManufacturer Manufacturer { get; private set; }

        /// <summary>
        /// Reference to a socket owned by the Socket Module.
        /// Stored as a plain Guid so the Motherboard Module only depends on
        /// Socket.Contracts (Guid-based) and never on Socket Domain types.
        /// </summary>
        public Guid SocketId { get; private set; }

        private ChipsetProfile()
        {
        }

        public static ChipsetProfile Create(string name, ChipsetManufacturer manufacturer, Guid socketId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Chipset name cannot be empty.",
                    nameof(name));

            if (socketId == Guid.Empty)
                throw new ArgumentException(
                    "Socket id cannot be empty.",
                    nameof(socketId));

            var chipset = new ChipsetProfile
            {
                Id = ChipsetProfileId.New(),
                Name = name.Trim(),
                Manufacturer = manufacturer,
                SocketId = socketId
            };

            chipset.AddDomainEvent(new ChipsetProfileCreatedEvent(chipset.Id, chipset.Name));

            return chipset;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Chipset name cannot be empty.",
                    nameof(name));

            Name = name.Trim();
        }

        public void UpdateManufacturer(ChipsetManufacturer manufacturer)
            => Manufacturer = manufacturer;

        public void UpdateSocket(Guid socketId)
        {
            if (socketId == Guid.Empty)
                throw new ArgumentException(
                    "Socket id cannot be empty.",
                    nameof(socketId));

            SocketId = socketId;
        }
    }
}
