// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnixEpochDateTimeJsonConverter.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the UnixEpochDateTimeJsonConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rachio.NET.Service.Infrastructure.Json
{
    public class UnixEpochDateTimeJsonConverter : DateTimeConverterBase
    {
        private static readonly UnixEpochDateTimeConverter Converter = new UnixEpochDateTimeConverter();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var millisecondsSinceEpoch = Converter.Convert((DateTime)value);
            writer.WriteRawValue(millisecondsSinceEpoch.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var millisecondsSinceEpoch = (long)reader.Value;
            return Converter.Convert(millisecondsSinceEpoch);
        }
    }
}
