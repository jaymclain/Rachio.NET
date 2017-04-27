using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Rachio.NET.Service
{
    public class RachioServiceProvider : IRachioServiceProvider
    {
        private const string ServiceUrlFormat = "https://api.rach.io/{0}/public/{1}/{2}";
        private const string ServiceApiVersion = "1";
        private const string PersonEntity = "person";
        private const string Info = "info";

        private readonly HttpClient _httpClient;

        public RachioServiceProvider(ServiceOptions options)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.AccessToken);
        }

        // "person/info"
        public Person Person()
        {
            var url = new Uri(string.Format(ServiceUrlFormat, ServiceApiVersion, PersonEntity, Info));
            return GetAsync<Person>(url).Result;
        }

        public Person Person(string id)
        {
            var url = new Uri(string.Format(ServiceUrlFormat, ServiceApiVersion, PersonEntity, id));
            return GetAsync<Person>(url).Result;
        }

        public Task<T> GetAsync<T>(Uri url)
        {
            var response = _httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            return Task.Run(() => JsonConvert.DeserializeObject<T>(content));
        }
    }
}
