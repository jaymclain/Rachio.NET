// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Forecast.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the Forecast type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;

namespace Rachio.NET.Service.Model
{
    public class Forecast
    {
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime Time { get; set; }
        [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
        public DateTime LocalizedTimeStamp { get; set; }
        public DateTime PrettyTime { get; set; }
        [JsonProperty("calculatedPrecip")]
        public double CalculatedPrecipitation { get; set; }
        [JsonProperty("precipIntensity")]
        public double PrecipitationIntensity { get; set; }
        [JsonProperty("precipProbability")]
        public double PrecipitationProbability { get; set; }
        public double CloudCover { get; set; }
        public double CurrentTemperature { get; set; }
        public double WindSpeed { get; set; }
        public double DewPoint { get; set; }
        public double Humidity { get; set; }
        public string UnitType { get; set; }
        public Uri IconUrl { get; set; }
        public string WeatherSummary { get; set; }
        public string WeatherType { get; set; }
    }
}
