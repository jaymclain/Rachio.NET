// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnixEpochDateTimeJsonConverter.cs" company="HomeRun Software Systems">
//   Copyright (c) 2017 Jay McLain
//
//   Permission is hereby granted, free of charge, to any person 
//   obtaining a copy of this software and associated documentation
//   files (the "Software"), to deal in the Software without
//   restriction, including without limitation the rights to use,
//   copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the
//   Software is furnished to do so, subject to the following
//   conditions:
//
//   The above copyright notice and this permission notice shall be
//   included in all copies or substantial portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//   EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//   OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
//   NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//   HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//   WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//   FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//   OTHER DEALINGS IN THE SOFTWARE.
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
