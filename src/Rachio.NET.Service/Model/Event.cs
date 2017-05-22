// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Event.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the Event type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service.Model
{
    public class Event : Entity
    {
        public string DeviceId { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime EventDate { get; set; }
        public Uri IconUrl { get; set; }
        public string Summary { get; set; }
    }
}
