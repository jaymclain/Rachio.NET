// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceTests.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the DeviceTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using Rachio.NET.Service;
using Rachio.NET.Service.Model;
using Xunit;

namespace Rachio.Service.AcceptanceTests;

public class DeviceTests
{
    [Fact]
    public void When_Invoked_Should_Get_Devices()
    {
        // Arrange
        var service = RachioService.Create(new TestServiceOptions());

        // Act
        var devices = service.Person()?.Devices
                      ?? Enumerable.Empty<Device>();

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

        var devices = service.Person()?.Devices
                      ?? Enumerable.Empty<Device>();

        foreach (var device in devices)
        {
            // Act
            var currentSchedule = device.CurrentSchedule();
                
            // Assert
            Assert.NotNull(currentSchedule);
        }
    }

    [Fact]
    public void When_Invoked_Should_Get_Events()
    {
        // Arrange
        var service = RachioService.Create(new TestServiceOptions());
        var device = service.Person()?.Devices.FirstOrDefault();

        // Act
        var today = DateTime.UtcNow;
        var events = device?.Events(today.AddDays(-7), today);

        // Assert
        Assert.NotNull(events);
        Assert.NotEmpty(events);
    }

    [Fact]
    public void When_Invoked_Should_Get_ScheduleItems()
    {
        // Arrange
        var service = RachioService.Create(new TestServiceOptions());
        var device = service.Person()?.Devices.First();

        // Act
        var scheduleItems = device?.ScheduleItems();

        // Assert
        Assert.NotNull(scheduleItems);
        Assert.NotEmpty(scheduleItems);
    }

    [Fact]
    public void When_Invoked_Should_Get_Forecast()
    {
        // Arrange
        var service = RachioService.Create(new TestServiceOptions());
        var device = service.Person()?.Devices.First();

        // Act
        var forecast = device?.Forecast();

        // Assert
        Assert.NotNull(forecast);
    }

    [Fact]
    public void When_Invoked_Should_StopWater()
    {
        // Arrange
        var service = RachioService.Create(new TestServiceOptions());

        // Act
        service.Person()?.Devices.First().StopWater();

        // Assert
    }

    [Fact]
    public void When_Invoked_Should_RainDelay()
    {
        // Arrange
        var service = RachioService.Create(new TestServiceOptions());

        // Act
        service.Person()?.Devices.First().RainDelay(1);

        // Assert
    }
}