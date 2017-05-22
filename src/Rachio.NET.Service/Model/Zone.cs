// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Zone.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the Zone type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service.Model
{
    public class Zone : Entity
    {
        public int ZoneNumber { get; set; }
        public string Name { get; set; }
        public Uri ImageUrl { get; set; }
        public bool Enabled { get; set; }
        public double RootZoneDepth { get; set; }
        public double AvailableWater { get; set; }
        public double DepthOfWater { get; set; }
        public double SaturatedDepthOfWater { get; set; }
        public double Efficiency { get; set; }
        public double FixedRuntime { get; set; }
        public double ManagementAllowedDepletion { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime LastWateredDate { get; set; }
        [JsonConverter(typeof(UnixTimespanConverter))]
        public TimeSpan LastWateredDuration { get; set; }
        [JsonConverter(typeof(UnixTimespanConverter))]
        public TimeSpan RunTime { get; set; }
        [JsonConverter(typeof(UnixTimespanConverter))]
        public TimeSpan RunTimeNoMultiplier { get; set; }
        [JsonConverter(typeof(UnixTimespanConverter))]
        public TimeSpan MaxRunTime { get; set; }
        public bool ScheduleDataModified { get; set; }
        public int YardAreaSquareFeet { get; set; }
        public CustomCrop CustomCrop { get; set; }
        public CustomNozzle CustomNozzle { get; set; }
        public CustomShade CustomShade { get; set; }
        public CustomSlope CustomSlope { get; set; }
        public CustomSoil CustomSoil { get; set; }
        //public WateringAdjustmentRuntimes
    }
}
