// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryJsonConverter.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the FactoryJsonConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rachio.NET.Service.Infrastructure.Json
{
    public class FactoryJsonConverter : JsonConverter
    {
        private readonly Type _type;

        protected FactoryJsonConverter(Type type)
        {
            _type = type;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException("FactoryJsonConverter can only for deserializing.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jObject = JObject.Load(reader);

            var target = Create(objectType);

            if (target == null)
                throw new JsonSerializationException("No object created.");

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public virtual object Create(Type objectType)
        {
            return Activator.CreateInstance(_type);
        }

        public override bool CanConvert(Type objectType)
        {
            return _type.GetTypeInfo().IsAssignableFrom(objectType);
        }

        public override bool CanWrite => false;
    }
}
