using System;

namespace Rachio.NET.Service
{
    public class CustomNozzle
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public Uri ImageUrl { get; set; }
        public double InchesPerHour { get; set; }
    }
}