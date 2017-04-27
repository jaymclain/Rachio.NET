using System.Collections.Generic;

namespace Rachio.NET.Service
{
    public class Person
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }
}
