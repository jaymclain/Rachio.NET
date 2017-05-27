using System.Threading.Tasks;
using Rachio.NET.Service.Model;

namespace Rachio.NET.Service
{
    public interface IRachioServiceProvider
    {
        Task<T> GetAsync<T>(string entity, string entityId = null, string action = null, object parameters = null);
        Task PutAsync(string entity, object parameters, string action = null);
    }
}
