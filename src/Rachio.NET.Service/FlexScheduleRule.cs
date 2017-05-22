using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service
{
    public class FlexScheduleRule
    {
        public string Id { get; set; }
        public bool Enabled { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime StartDate { get; set; }
        public bool CycleSoak { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string ExternalName { get; set; }
        public string Summary { get; set; }
        [JsonConverter(typeof(UnixTimespanConverter))]
        public TimeSpan TotalDuration { get; set; }
        [JsonConverter(typeof(UnixTimespanConverter))]
        public TimeSpan TotalDurationNoCycle { get; set; }
        public IEnumerable<string> ScheduleJobTypes { get; set; }
        public IEnumerable<ScheduleZone> Zones { get; set; }
    }
}
