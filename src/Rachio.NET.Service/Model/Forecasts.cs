// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Forecasts.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the Forecasts type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rachio.NET.Service.Model
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Forecasts
    {
        public Forecast Current { get; set; }
        [JsonProperty("Forecast")]
        public IEnumerable<Forecast> DailyForecasts { get; set; }
    }
}
