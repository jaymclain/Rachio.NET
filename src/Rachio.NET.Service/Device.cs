using System.Collections.Generic;

namespace Rachio.NET.Service
{
    public class Device
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public IEnumerable<Zone> Zones { get; set; }
    }
}
