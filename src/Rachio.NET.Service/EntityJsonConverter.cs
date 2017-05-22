using System;
using Rachio.NET.Service.Infrastructure;
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
