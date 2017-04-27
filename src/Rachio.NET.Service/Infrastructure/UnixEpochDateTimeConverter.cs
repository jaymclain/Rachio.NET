using System;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Rachio.NET.Service.Infrastructure
{
    public class UnixEpochDateTimeConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = (DateTime) value;
            writer.WriteRawValue((date - _epoch).TotalMilliseconds + "000");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var ms = (long)reader.Value / 1000.0;
            return _epoch.AddMilliseconds(ms);
        }
    }
}
