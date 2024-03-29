﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryJsonConverter.cs" company="HomeRun Software Systems">
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
//   Defines the FactoryJsonConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rachio.NET.Service.Infrastructure.Json;

public class FactoryJsonConverter : JsonConverter
{
    private readonly Type _type;

    protected FactoryJsonConverter(Type type)
    {
        _type = type;
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotSupportedException("FactoryJsonConverter can only for deserializing.");
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
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

    public virtual object? Create(Type objectType)
    {
        return Activator.CreateInstance(_type);
    }

    public override bool CanConvert(Type objectType)
    {
        return _type.GetTypeInfo().IsAssignableFrom(objectType);
    }

    public override bool CanWrite => false;
}