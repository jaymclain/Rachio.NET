using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service
{
    public class RachioEntitySerializer : ISerializer
    {
        private readonly JsonConverter[] _entityConverters; 

        public RachioEntitySerializer(IRachioServiceProvider serviceProvider)
        {
            var entityType = typeof(Entity);
            _entityConverters = entityType.GetTypeInfo().Assembly
                .GetTypes()
                .Where(t => t != entityType && entityType.GetTypeInfo().IsAssignableFrom(t))
                .Select(t => new EntityJsonConverter(t, serviceProvider))
                .Cast<JsonConverter>()
                .ToArray();
        }

        public T DeserializeObject<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content, _entityConverters);
        }
    }
}
