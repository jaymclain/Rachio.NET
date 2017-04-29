using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service
{
    public class CustomSoil
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Uri ImageUrl { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime CreateDate { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime LastUpdateDate { get; set; }
        public string Category { get; set; }
        public bool Editable { get; set; }
        public double InfiltrationRate { get; set; }
        public double PercentAvailableWater { get; set; }
    }
}