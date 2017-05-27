using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;

namespace Rachio.NET.Service.Model
{
    public class CustomSoil
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Uri ImageUrl { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime CreateDate { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime LastUpdateDate { get; set; }
        public string Category { get; set; }
        public bool Editable { get; set; }
        public double InfiltrationRate { get; set; }
        public double PercentAvailableWater { get; set; }
    }
}