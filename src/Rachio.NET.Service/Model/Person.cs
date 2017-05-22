using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service.Model
{
    public class Person : Entity
    {
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime CreateDate { get; set; }
        public bool Deleted { get; set; }
        public bool Enabled { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DisplayUnit { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }
}
