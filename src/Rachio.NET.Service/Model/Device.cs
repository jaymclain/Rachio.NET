// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Device.cs" company="HomeRun Software Systems">
//   Copyright (c) 2017 Jay McLain
//
//   Permission is hereby granted, free of charge, to any person 
//   obtaining a copy of this software and associated documentation
//   files (the "Software"), to deal in the Software without
//   restriction, including without limitation the rights to use,
//   copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the
//   Software is furnished to do so, subject to the following
//   conditions:
//
//   The above copyright notice and this permission notice shall be
//   included in all copies or substantial portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//   EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//   OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
//   NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//   HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//   WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//   FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//   OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Defines the Device type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;
using System;
using System.Collections.Generic;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service.Model;

public class Device : Entity
{
    private const string DeviceEntity = "device";
    private const string CurrentScheduleAction = "current_schedule";
    private const string EventAction = "event";
    private const string ScheduleItemAction = "scheduleitem";
    private const string ForecastAction = "forecast";
    private const string StopWaterAction = "stop_water";
    private const string RainDelayAction = "rain_delay";
    private const string OnAction = "on";
    private const string OffAction = "off";

    private static readonly UnixEpochDateTimeConverter Converter = new();

    [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
    public DateTime CreateDate { get; set; }
    public string? MacAddress { get; set; }
    public string? Name { get; set; }
    public string? Model { get; set; }
    public string? SerialNumber { get; set; }
    public string? Status { get; set; }
    [JsonProperty("on")]
    public bool IsOn { get; set; }
    public bool Paused { get; set; }
    public string? ScheduleModeType { get; set; }
    public bool Deleted { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Elevation { get; set; }
    public string? TimeZone { get; set; }
    public int UtcOffset { get; set; }
    public int Zip { get; set; }
    public IEnumerable<FlexScheduleRule> FlexScheduleRules { get; set; } = new List<FlexScheduleRule>();
    public IEnumerable<Zone> Zones { get; set; } = new List<Zone>();

    public CurrentSchedule? CurrentSchedule()
    {
        // device/{id}/current_schedule
        return ServiceProvider.GetAsync<CurrentSchedule>(DeviceEntity, Id, CurrentScheduleAction).Result;
    }

    public IEnumerable<Event>? Events(DateTime startTime, DateTime endTime)
    {
        // device/{id}/event?startTime={startTime}&endTime={endTime}
        return ServiceProvider.GetAsync<IEnumerable<Event>>(
            DeviceEntity, 
            Id, 
            EventAction, 
            new
            {
                startTime = Converter.Convert(startTime),
                endTime = Converter.Convert(endTime)
            }).Result;
    }

    public IEnumerable<ScheduleItem>? ScheduleItems()
    {
        // device/{id}/scheduleitem
        return ServiceProvider.GetAsync<IEnumerable<ScheduleItem>>(DeviceEntity, Id, ScheduleItemAction).Result;
    }

    public Forecasts? Forecast(string units = "US")
    {
        // device/{id}/forecast?units={units}
        return ServiceProvider.GetAsync<Forecasts>(DeviceEntity, Id, ForecastAction, new { units }).Result;
    }

    public void StopWater()
    {
        // device/{id}/stop_water
        ServiceProvider.PutAsync(DeviceEntity, new { id = Id }, StopWaterAction).Wait();
    }

    /// <summary>
    /// Rain delay device
    /// </summary>
    /// <param name="duration">Duration in seconds. Range is 0 to 604800 (7 days). Default is 1 day.</param>
    public void RainDelay(int duration = 86400)
    {
        // device/{id}/rain_delay
        ServiceProvider.PutAsync(DeviceEntity, new { id = Id, duration }, RainDelayAction);
    }

    /// <summary>
    /// Turn ON all features of the device (schedules, weather intelligence, water budget, etc.)
    /// </summary>
    public void On()
    {
        // device/{id}/on
        ServiceProvider.PutAsync(DeviceEntity, new { id = Id }, OnAction);
    }

    public void Off()
    {
        // device/{id}/off
        ServiceProvider.PutAsync(DeviceEntity, new { id = Id }, OffAction);
    }
}