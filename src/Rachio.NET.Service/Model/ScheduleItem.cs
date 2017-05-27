// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduleItem.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the ScheduleItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;

namespace Rachio.NET.Service.Model
{
    using System.Collections.Generic;

    public class ScheduleItem : Entity
    {
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime Date { get; set; }
        public DateTime Iso8601Date { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime AbsoluteStartDate { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleRuleId { get; set; }
        public string ScheduleType { get; set; }
        public bool CycleSoak { get; set; }
        public int TotalCycleCount { get; set; }
        public int TotalDuration { get; set; }
        public IEnumerable<ScheduleZone> Zones { get; set; }
    }
}
