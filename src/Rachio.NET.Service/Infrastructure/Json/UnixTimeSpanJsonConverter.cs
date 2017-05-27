// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnixTimeSpanJsonConverter.cs" company="HomeRun Software Systems">
//   HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the UnixTimeSpanJsonConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace Rachio.NET.Service.Infrastructure.Json
{
    public class UnixTimeSpanJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            return new TimeSpan((long)reader.Value * TimeSpan.TicksPerSecond);
        }

        public override bool CanConvert(Type type)
        {
            return type == typeof(DateTime);
        }
    }
}
