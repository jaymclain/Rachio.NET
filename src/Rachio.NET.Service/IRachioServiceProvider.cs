using System.Threading.Tasks;

namespace Rachio.NET.Service
{
    public interface IRachioServiceProvider
    {
        Task<T> GetAsync<T>(string entity, string entityId = null, string action = null) where T : Entity, new();
    }
}
