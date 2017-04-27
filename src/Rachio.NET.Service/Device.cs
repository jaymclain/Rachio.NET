using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service
{
    public class Device
    {
        public string Id { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime CreateDate { get; set; }
        public string MacAddress { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public bool On { get; set; }
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
    }
}
