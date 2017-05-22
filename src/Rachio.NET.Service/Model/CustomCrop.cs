using System;

namespace Rachio.NET.Service.Model
{
    public class CustomCrop
    {
        public string Name { get; set; }
        public Uri ImageUrl { get; set; }
        public double Coefficient { get; set; }
    }
}