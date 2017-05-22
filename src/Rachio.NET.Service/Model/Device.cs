// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Device.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the Device type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service.Model
{
    public class Device : Entity
    {
        private const string DeviceEntity = "device";
        private const string CurrentScheduleAction = "current_schedule";
        private const string EventAction = "event";
        private const string StopWaterAction = "stop_water";
        private const string RainDelayAction = "rain_delay";
        private const string OnAction = "on";
        private const string OffAction = "off";

        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime CreateDate { get; set; }
        public string MacAddress { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        [JsonProperty("on")]
        public bool IsOn { get; set; }
        public bool Paused { get; set; }
        public string ScheduleModeType { get; set; }
        public bool Deleted { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }
        public string TimeZone { get; set; }
        public int UtcOffset { get; set; }
        public int Zip { get; set; }
        public IEnumerable<FlexScheduleRule> FlexScheduleRules { get; set; }
        public IEnumerable<Zone> Zones { get; set; }

        public CurrentSchedule CurrentSchedule()
        {
            return ServiceProvider.GetAsync<CurrentSchedule>(DeviceEntity, Id, CurrentScheduleAction).Result;
        }

        public Event Event(DateTime startTime, DateTime endTime)
        {
            return ServiceProvider.GetAsync<Event>(DeviceEntity, Id, EventAction).Result;
        }

        public ScheduleItem ScheduleItem()
        {
            return ServiceProvider.GetAsync<ScheduleItem>(DeviceEntity, Id).Result;
        }

        public Forecast Forecast(string units)
        {
            throw new NotImplementedException();
        }

        public void StopWater()
        {
            ServiceProvider.PutAsync(DeviceEntity, new { id = Id }, StopWaterAction).Wait();
        }

        /// <summary>
        /// Rain delay device
        /// </summary>
        /// <param name="duration">Duration in seconds. Range is 0 to 604800 (7 days)</param>
        public void RainDelay(int? duration = null)
        {
            ServiceProvider.PutAsync(DeviceEntity, new { id = Id, duration }, RainDelayAction);
        }

        /// <summary>
        /// Turn ON all features of the device (schedules, weather intelligence, water budget, etc.)
        /// </summary>
        public void On()
        {
            ServiceProvider.PutAsync(DeviceEntity, new { id = Id }, OnAction);
        }

        public void Off()
        {
            ServiceProvider.PutAsync(DeviceEntity, new { id = Id }, OffAction);
        }
    }
}
