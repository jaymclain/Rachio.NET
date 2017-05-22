using System;

namespace Rachio.NET.Service.Model
{
    public class CustomShade
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri ImageUrl { get; set; }
        public double Exposure { get; set; }
    }
}