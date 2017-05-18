using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Rachio.NET.Service.Infrastructure;

namespace Rachio.NET.Service
{
    public class RachioServiceProvider : IRachioServiceProvider
    {
        private readonly ISerializer _serializer;
        private const int ServiceApiVersion = 1;
        private const string ServiceUrlFormat = "https://api.rach.io/{0}/public/";

        private readonly HttpClient _httpClient;

        public RachioServiceProvider(ServiceOptions options)
        {
            _serializer = new RachioEntitySerializer(this);

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.AccessToken);
        }

        public Task<T> GetAsync<T>(string entity, string entityId, string action) where T : Entity, new()
        {
            var url = new Uri(string.Format(ServiceUrlFormat, ServiceApiVersion));
            url = new Uri(url, $"{entity}/");
            if (!string.IsNullOrWhiteSpace(entityId)) url = new Uri(url, $"{entityId}/");
            if (!string.IsNullOrWhiteSpace(action)) url = new Uri(url, $"{action}");

            return GetAsync<T>(url);
        }

        private Task<T> GetAsync<T>(Uri url) where T : Entity, new()
        {
            var response = _httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return Task.Run(() => _serializer.DeserializeObject<T>(content));
        }
    }
}
