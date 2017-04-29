using System;
using Newtonsoft.Json;

namespace Rachio.NET.Service.Infrastructure
{
    public class UnixTimespanConverter : JsonConverter
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            return new TimeSpan((long)reader.Value * TimeSpan.TicksPerSecond);
        }

        public override bool CanConvert(Type type)
        {
            return type == typeof(DateTime);
        }
    }
}
