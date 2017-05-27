// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RachioServiceProvider.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the RachioServiceProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Rachio.NET.Service.Infrastructure.Json;
using Rachio.NET.Service.Model;

namespace Rachio.NET.Service
{
    public class RachioServiceProvider : IRachioServiceProvider
    {
        private const int ServiceApiVersion = 1;
        private const string ServiceUrlFormat = "https://api.rach.io/{0}/public/";

        private readonly ISerializer _serializer;
        private readonly HttpClient _httpClient;

        public RachioServiceProvider(ServiceOptions options)
        {
            _serializer = new RachioEntitySerializer(this);

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.AccessToken);
        }

        private static string GetQueryStringFromParameterObject(object parameters)
        {
            return parameters.GetType().GetTypeInfo().DeclaredProperties.Aggregate(
                new StringBuilder(),
                (q, p) =>
                    {
                        if (q.Length > 0)
                        {
                            q.Append("&");
                        }

                        return q.Append($"{p.Name}={p.GetValue(parameters)}");
                    }).ToString();
        }

        public Task<T> GetAsync<T>(string entity, string entityId, string action, object parameters)
        {
            var url = new Uri(string.Format(ServiceUrlFormat, ServiceApiVersion));
            url = new Uri(url, $"{entity}/");

            if (!string.IsNullOrWhiteSpace(entityId))
            {
                url = new Uri(url, $"{entityId}/");
            }

            if (!string.IsNullOrWhiteSpace(action))
            {
                url = new Uri(url, $"{action}");
            }

            if (parameters != null)
            {
                var uri = new UriBuilder(url) { Query = GetQueryStringFromParameterObject(parameters) };
                url = uri.Uri;
            }

            return GetAsync<T>(url);
        }

        public Task PutAsync(string entity, object parameters, string action)
        {
            var url = new Uri(string.Format(ServiceUrlFormat, ServiceApiVersion));
            url = new Uri(url, $"{entity}/");

            if (!string.IsNullOrWhiteSpace(action))
            {
                url = new Uri(url, $"{action}");
            }

            var body = _serializer.Serialize(parameters);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            return _httpClient.PutAsync(url, content);
        }

        private Task<T> GetAsync<T>(Uri url)
        {
            var response = _httpClient.GetAsync(url).Result;
            if (!response.IsSuccessStatusCode)
            {
                ThrowError(response);
            }

            var content = response.Content.ReadAsStringAsync().Result;
            return Task.Run(() => _serializer.DeserializeObject<T>(content));
        }

        private void ThrowError(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            var error = _serializer.DeserializeObject<Error>(content);
            throw new RachioServiceProviderException(error.Code, error.Message);
        }
    }
}
