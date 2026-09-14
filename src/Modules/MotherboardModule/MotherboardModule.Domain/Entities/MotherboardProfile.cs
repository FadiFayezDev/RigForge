using BuildingBlocks.Domain.Bases;
using MotherboardModule.Domain.Enums;
using MotherboardModule.Domain.Events;
using MotherboardModule.Domain.Primitives.Identifiers;

namespace MotherboardModule.Domain.Entities
{
    public class MotherboardProfile : AggregateRoot<MotherboardProfileId>
    {
        public string Name { get; private set; } = default!;
        public Manufacturer Manufacturer { get; private set; }

        #region Ram Properties
        public int RamSlots { get; private set; }
        public RamType RamType { get; private set; }
        public int MaxRamCapacityGB { get; private set; }
        #endregion

        #region PCIe Properties
        public PCIeVersion PcieVersion { get; private set; }
        #endregion

        #region Storage Properties
        public int M2Slots { get; private set; }
        public int SataPorts { get; private set; }
        #endregion

        /// <summary>
        /// Reference to a socket owned by the Socket Module.
        /// Stored as a plain Guid so the Motherboard Module only depends on
        /// Socket.Contracts (Guid-based) and never on Socket Domain types.
        /// </summary>
        public Guid SocketId { get; private set; }

        private MotherboardProfile()
        {
        }

        public static MotherboardProfile Create(
            string name, 
            Manufacturer manufacturer, 
            Guid socketId, 
            int ramSlots, 
            RamType ramType, 
            int maxRamCapacityGB, 
            PCIeVersion pcieVersion, 
            int m2Slots, 
            int sataPorts)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Motherboard name cannot be empty.",
                    nameof(name));

            if (socketId == Guid.Empty)
                throw new ArgumentException(
                    "Socket id cannot be empty.",
                    nameof(socketId));

            if (ramSlots == 0)
                throw new ArgumentException(
                    "Motherboard must have at least one RAM slot.",
                    nameof(ramSlots));

            if (m2Slots < 0)
                throw new ArgumentException(
                    "M2 slots cannot be negative.",
                    nameof(m2Slots));

            if (sataPorts < 0)
                throw new ArgumentException(
                    "SATA ports cannot be negative.",
                    nameof(sataPorts));

            if(maxRamCapacityGB < 0)
                throw new ArgumentException(
                    "Maximum RAM capacity cannot be negative.",
                    nameof(maxRamCapacityGB));

            var motherboard = new MotherboardProfile
            {
                Id = MotherboardProfileId.New(),
                Name = name.Trim(),
                Manufacturer = manufacturer,
                SocketId = socketId,
                RamSlots = ramSlots,
                RamType = ramType,
                MaxRamCapacityGB = maxRamCapacityGB,
                PcieVersion = pcieVersion,
                M2Slots = m2Slots,
                SataPorts = sataPorts
            };

            motherboard.AddDomainEvent(new MotherboardProfileCreatedEvent(motherboard.Id, motherboard.Name));

            return motherboard;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Motherboard name cannot be empty.",
                    nameof(name));

            Name = name.Trim();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
            => Manufacturer = manufacturer;

        public void UpdateSocket(Guid socketId)
        {
            if (socketId == Guid.Empty)
                throw new ArgumentException(
                    "Socket id cannot be empty.",
                    nameof(socketId));

            SocketId = socketId;
        }

        public void UpdateRamSlots(int ramSlots)
        {
            if (ramSlots < 0)
                throw new ArgumentException(
                    "RAM slots cannot be negative.",
                    nameof(ramSlots));
            RamSlots = ramSlots;
        }

        public void UpdateRamType(RamType ramType)
            => RamType = ramType;

        public void UpdateMaxRamCapacityGB(int maxRamCapacityGB)
        {
            if (maxRamCapacityGB < 0)
                throw new ArgumentException(
                    "Maximum RAM capacity cannot be negative.",
                    nameof(maxRamCapacityGB));
            MaxRamCapacityGB = maxRamCapacityGB;
        }

        public void UpdatePcieVersion(PCIeVersion pcieVersion)
            => PcieVersion = pcieVersion;
    }
}
