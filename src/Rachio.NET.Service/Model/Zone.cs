// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Zone.cs" company="HomeRun Software Systems">
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
//   Defines the Zone type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;

namespace Rachio.NET.Service.Model;

public class Zone : Entity
{
    private const string ZoneEntity = "zone";
    private const string StartAction = "start";

    public int ZoneNumber { get; set; }
    public string? Name { get; set; }
    public Uri? ImageUrl { get; set; }
    public bool Enabled { get; set; }
    public double RootZoneDepth { get; set; }
    public double AvailableWater { get; set; }
    public double DepthOfWater { get; set; }
    public double SaturatedDepthOfWater { get; set; }
    public double Efficiency { get; set; }
    public double FixedRuntime { get; set; }
    public double ManagementAllowedDepletion { get; set; }
    [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
    public DateTime LastWateredDate { get; set; }
    [JsonConverter(typeof(UnixTimeSpanJsonConverter))]
    public TimeSpan LastWateredDuration { get; set; }
    [JsonConverter(typeof(UnixTimeSpanJsonConverter))]
    public TimeSpan RunTime { get; set; }
    [JsonConverter(typeof(UnixTimeSpanJsonConverter))]
    public TimeSpan RunTimeNoMultiplier { get; set; }
    [JsonConverter(typeof(UnixTimeSpanJsonConverter))]
    public TimeSpan MaxRunTime { get; set; }
    public bool ScheduleDataModified { get; set; }
    public int YardAreaSquareFeet { get; set; }
    public CustomCrop? CustomCrop { get; set; }
    public CustomNozzle? CustomNozzle { get; set; }
    public CustomShade? CustomShade { get; set; }
    public CustomSlope? CustomSlope { get; set; }
    public CustomSoil? CustomSoil { get; set; }
    //public WateringAdjustmentRuntimes

    /// <summary>
    /// Start a zone
    /// </summary>
    /// <param name="duration">Duration in seconds. Range is 0 to 10800 (3 hours). Default is 15 minutes.</param>
    public void Start(int duration = 900)
    {
        ServiceProvider.PutAsync(ZoneEntity, new { id = Id, duration }, StartAction);
    }
}