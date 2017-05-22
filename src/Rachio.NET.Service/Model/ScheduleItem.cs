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
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service.Model
{
    using System.Collections.Generic;

    public class ScheduleItem : Entity
    {
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime StartDate { get; set; }
        public List<ScheduleZone> Zones { get; set; }
        public string ScheduleRuleId { get; set; }
        public bool CycleSoak { get; set; }
        public int TotalDuration { get; set; }
    }
}
