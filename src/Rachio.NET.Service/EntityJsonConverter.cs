// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityJsonConverter.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the EntityJsonConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Rachio.NET.Service.Infrastructure.Json;
using Rachio.NET.Service.Model;

namespace Rachio.NET.Service
{
    public class EntityJsonConverter : FactoryJsonConverter
    {
        private readonly Type _type;
        private readonly IRachioServiceProvider _serviceProvider;

        public EntityJsonConverter(Type type, IRachioServiceProvider serviceProvider)
            : base(type)
        {
            _type = type;
            _serviceProvider = serviceProvider;
        }

        public override object Create(Type objectType)
        {
            var entity = (Entity)Activator.CreateInstance(_type);
            entity.ServiceProvider = _serviceProvider;
            return entity;
        }
    }
}
