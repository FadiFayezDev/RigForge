using MotherboardModule.Domain.Entities;
using MotherboardModule.Domain.Enums;
using MotherboardModule.Domain.Events;

namespace test
{
    public class ChipsetProfileTests
    {
        [Fact]
        public void Create_WithValidData_SetsPropertiesAndRaisesCreatedEvent()
        {
            var socketId = Guid.NewGuid();

            var profile = ChipsetProfile.Create("B650", ChipsetManufacturer.AMD, socketId);

            Assert.Equal("B650", profile.Name);
            Assert.Equal(ChipsetManufacturer.AMD, profile.Manufacturer);
            Assert.Equal(socketId, profile.SocketId);
            Assert.NotEqual(Guid.Empty, profile.Id.Value);
            Assert.Contains(profile.DomainEvents, e => e is ChipsetProfileCreatedEvent);
        }

        [Fact]
        public void Create_WithEmptyName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                ChipsetProfile.Create("  ", ChipsetManufacturer.Intel, Guid.NewGuid()));
        }

        [Fact]
        public void Create_WithEmptySocketId_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                ChipsetProfile.Create("Z790", ChipsetManufacturer.Intel, Guid.Empty));
        }

        [Fact]
        public void UpdateSocket_WithEmptySocketId_ThrowsArgumentException()
        {
            var profile = ChipsetProfile.Create("X670E", ChipsetManufacturer.AMD, Guid.NewGuid());

            Assert.Throws<ArgumentException>(() => profile.UpdateSocket(Guid.Empty));
        }

        [Fact]
        public void UpdateSocket_WithValidSocketId_UpdatesSocketId()
        {
            var profile = ChipsetProfile.Create("X670E", ChipsetManufacturer.AMD, Guid.NewGuid());
            var newSocketId = Guid.NewGuid();

            profile.UpdateSocket(newSocketId);

            Assert.Equal(newSocketId, profile.SocketId);
        }

        [Fact]
        public void UpdateName_WithEmptyName_ThrowsArgumentException()
        {
            var profile = ChipsetProfile.Create("B650", ChipsetManufacturer.AMD, Guid.NewGuid());

            Assert.Throws<ArgumentException>(() => profile.UpdateName("  "));
        }

        [Fact]
        public void UpdateManufacturer_UpdatesManufacturer()
        {
            var profile = ChipsetProfile.Create("B650", ChipsetManufacturer.AMD, Guid.NewGuid());

            profile.UpdateManufacturer(ChipsetManufacturer.Intel);

            Assert.Equal(ChipsetManufacturer.Intel, profile.Manufacturer);
        }
    }
}
