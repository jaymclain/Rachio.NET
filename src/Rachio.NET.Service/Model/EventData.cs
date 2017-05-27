// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventData.cs" company="HomeRun Software Systems">
//   HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the EventData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;

namespace Rachio.NET.Service.Model
{
    public class EventData : Entity
    {
        public string Key { get; set; }
        public string ConvertedValue { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime CreateDate { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime LastUpdateDate { get; set; }
    }
}
