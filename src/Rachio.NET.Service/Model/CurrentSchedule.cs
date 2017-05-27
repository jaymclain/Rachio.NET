// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Device.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the Device type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;

namespace Rachio.NET.Service.Model
{
    public class CurrentSchedule : Entity
    {
        public string DeviceId { get; set; }
        public string ScheduleId { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string ZoneId { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime ZoneStartDate { get; set; }
        public int ZoneDuration { get; set; }
        public int CycleCount { get; set; }
        public int TotalCycleCount { get; set; }
        public bool Cycling { get; set; }
        public int DurationNoCycle { get; set; }
    }
}
