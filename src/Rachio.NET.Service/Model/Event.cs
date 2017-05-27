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
using Rachio.NET.Service.Infrastructure.Json;

namespace Rachio.NET.Service.Model
{
    using System.Collections.Generic;

    public class Event : Entity
    {
        public string CorrelationId { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime CreateDate { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime LastUpdateDate { get; set; }
        public string DeviceId { get; set; }
        public string Category { get; set; }
        public string Topic { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime EventDate { get; set; }
        public Uri IconUrl { get; set; }
        public string Summary { get; set; }
        public IEnumerable<EventData> EventDatas { get; set; }
    }
}
