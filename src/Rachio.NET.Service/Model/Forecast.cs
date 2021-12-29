// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Forecast.cs" company="HomeRun Software Systems">
//   Copyright (c) 2017 Jay McLain
//
//   Permission is hereby granted, free of charge, to any person 
//   obtaining a copy of this software and associated documentation
//   files (the "Software"), to deal in the Software without
//   restriction, including without limitation the rights to use,
//   copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the
//   Software is furnished to do so, subject to the following
//   conditions:
//
//   The above copyright notice and this permission notice shall be
//   included in all copies or substantial portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//   EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//   OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
//   NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//   HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//   WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//   FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//   OTHER DEALINGS IN THE SOFTWARE.
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
        public string? UnitType { get; set; }
        public Uri? IconUrl { get; set; }
        public string? WeatherSummary { get; set; }
        public string? WeatherType { get; set; }
    }
}
