﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrentSchedule.cs" company="HomeRun Software Systems">
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
//   Defines the Device type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;

namespace Rachio.NET.Service.Model;

public class CurrentSchedule : Entity
{
    public string? DeviceId { get; set; }
    public string? ScheduleId { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
    public DateTime? StartDate { get; set; }
    public int Duration { get; set; }
    public string? ZoneId { get; set; }
    [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
    public DateTime ZoneStartDate { get; set; }
    public int ZoneDuration { get; set; }
    public int CycleCount { get; set; }
    public int TotalCycleCount { get; set; }
    public bool Cycling { get; set; }
    public int DurationNoCycle { get; set; }
}