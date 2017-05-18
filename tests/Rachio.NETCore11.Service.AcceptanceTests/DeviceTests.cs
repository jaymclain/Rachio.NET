using System.Linq;
using Rachio.NET.Service;
using Xunit;

namespace Rachio.NETCore11.Service.AcceptanceTests
{
    public class DeviceTests
    {

        [Fact]
        public void When_Invoked_Should_Get_Devices()
        {
            // Arrange
            var service = RachioService.Create(new TestServiceOptions());

            // Act
            var devices = service.Person().Devices;

            // Assert
            foreach (var device in devices)
            {
                var deviceInfo = service.Device(device.Id);
                Assert.NotNull(deviceInfo);
            }
        }

        [Fact]
        public void When_Invoked_Should_Get_CurrentSchedule()
        {
            // Arrange
            var service = RachioService.Create(new TestServiceOptions());

            // Act
            var currentSchedule = service.Person().Devices.First().CurrentSchedule();

            // Assert
            Assert.NotNull(currentSchedule);
        }
    }
}
