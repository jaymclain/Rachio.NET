// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Event.cs" company="HomeRun Software Systems">
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
//   Defines the Event type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
    using System.Collections.Generic;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;

namespace Rachio.NET.Service.Model;

public class Event : Entity
{
    public string? CorrelationId { get; set; }
    [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
    public DateTime CreateDate { get; set; }
    [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
    public DateTime LastUpdateDate { get; set; }
    public string? DeviceId { get; set; }
    public string? Category { get; set; }
    public string? Topic { get; set; }
    public string? Type { get; set; }
    public string? SubType { get; set; }
    [JsonConverter(typeof(UnixEpochDateTimeJsonConverter))]
    public DateTime EventDate { get; set; }
    public Uri? IconUrl { get; set; }
    public string? Summary { get; set; }
    public IEnumerable<EventData> EventDatas { get; set; } = new List<EventData>();
}