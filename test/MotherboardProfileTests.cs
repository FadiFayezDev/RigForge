using MotherboardModule.Domain.Entities;
using MotherboardModule.Domain.Enums;
using MotherboardModule.Domain.Events;

namespace test
{
    public class MotherboardProfileTests
    {
        [Fact]
        public void Create_WithValidData_SetsPropertiesAndRaisesCreatedEvent()
        {
            var socketId = Guid.NewGuid();

            var profile = MotherboardProfile.Create(
                "ROG Strix B650E", Manufacturer.Asus, socketId,
                ramSlots: 4, ramType: RamType.DDR5, maxRamCapacityGB: 128,
                pcieVersion: PCIeVersion.PCIe5, m2Slots: 3, sataPorts: 4);

            Assert.Equal("ROG Strix B650E", profile.Name);
            Assert.Equal(Manufacturer.Asus, profile.Manufacturer);
            Assert.Equal(socketId, profile.SocketId);
            Assert.Equal(4, profile.RamSlots);
            Assert.Equal(RamType.DDR5, profile.RamType);
            Assert.Equal(128, profile.MaxRamCapacityGB);
            Assert.Equal(PCIeVersion.PCIe5, profile.PcieVersion);
            Assert.Equal(3, profile.M2Slots);
            Assert.Equal(4, profile.SataPorts);
            Assert.NotEqual(Guid.Empty, profile.Id.Value);
            Assert.Contains(profile.DomainEvents, e => e is MotherboardProfileCreatedEvent);
        }

        [Fact]
        public void Create_WithEmptyName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                MotherboardProfile.Create(
                    "  ", Manufacturer.MSI, Guid.NewGuid(),
                    ramSlots: 4, ramType: RamType.DDR5, maxRamCapacityGB: 128,
                    pcieVersion: PCIeVersion.PCIe5, m2Slots: 2, sataPorts: 4));
        }

        [Fact]
        public void Create_WithEmptySocketId_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                MotherboardProfile.Create(
                    "MAG B650", Manufacturer.MSI, Guid.Empty,
                    ramSlots: 4, ramType: RamType.DDR5, maxRamCapacityGB: 128,
                    pcieVersion: PCIeVersion.PCIe4, m2Slots: 2, sataPorts: 4));
        }

        [Fact]
        public void Create_WithZeroRamSlots_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                MotherboardProfile.Create(
                    "MAG B650", Manufacturer.MSI, Guid.NewGuid(),
                    ramSlots: 0, ramType: RamType.DDR5, maxRamCapacityGB: 128,
                    pcieVersion: PCIeVersion.PCIe4, m2Slots: 2, sataPorts: 4));
        }

        [Fact]
        public void UpdateSocket_WithEmptySocketId_ThrowsArgumentException()
        {
            var profile = MotherboardProfile.Create(
                "Aorus Elite", Manufacturer.Gigabyte, Guid.NewGuid(),
                ramSlots: 4, ramType: RamType.DDR5, maxRamCapacityGB: 128,
                pcieVersion: PCIeVersion.PCIe5, m2Slots: 3, sataPorts: 4);

            Assert.Throws<ArgumentException>(() => profile.UpdateSocket(Guid.Empty));
        }

        [Fact]
        public void UpdateSocket_WithValidSocketId_UpdatesSocketId()
        {
            var profile = MotherboardProfile.Create(
                "Aorus Elite", Manufacturer.Gigabyte, Guid.NewGuid(),
                ramSlots: 4, ramType: RamType.DDR5, maxRamCapacityGB: 128,
                pcieVersion: PCIeVersion.PCIe5, m2Slots: 3, sataPorts: 4);
            var newSocketId = Guid.NewGuid();

            profile.UpdateSocket(newSocketId);

            Assert.Equal(newSocketId, profile.SocketId);
        }
    }
}
