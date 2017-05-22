// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceTests.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the DeviceTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
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

            var devices = service.Person().Devices;

            foreach (var device in devices)
            {
                // Act
                var currentSchedule = device.CurrentSchedule();
                
                // Assert
                Assert.NotNull(currentSchedule);
            }
        }

        [Fact]
        public void When_Invoked_Should_StopWater()
        {
            // Arrange
            var service = RachioService.Create(new TestServiceOptions());

            // Act
            service.Person().Devices.First().StopWater();

            // Assert
        }

        [Fact]
        public void When_Invoked_Should_RainDelay()
        {
            // Arrange
            var service = RachioService.Create(new TestServiceOptions());

            // Act
            service.Person().Devices.First().RainDelay(1);

            // Assert
        }
    }
}
