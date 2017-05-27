// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RachioService.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the RachioService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Rachio.NET.Service.Model;

namespace Rachio.NET.Service
{
    public class RachioService
    {
        private const string InfoAction = "info";
        private const string PersonEntity = "person";
        private const string DeviceEntity = "device";
        private const string ZoneEntity = "zone";

        private readonly IRachioServiceProvider _serviceProvider;

        public RachioService(ServiceOptions serviceOptions)
        {
            _serviceProvider = new RachioServiceProvider(serviceOptions);
        }

        public static RachioService Create(ServiceOptions options)
        {
            return new RachioService(options);
        }

        public Person Person()
        {
            // person/info
            var current = _serviceProvider.GetAsync<Person>(PersonEntity, action: InfoAction).Result;
            return Person(current.Id);
        }

        public Person Person(string id)
        {
            // person/{id}
            return _serviceProvider.GetAsync<Person>(PersonEntity, id).Result;
        }

        public Device Device(string id)
        {
            // device/{id}
            return _serviceProvider.GetAsync<Device>(DeviceEntity, id).Result;
        }

        public Zone Zone(string id)
        {
            return _serviceProvider.GetAsync<Zone>(ZoneEntity, id).Result;
        }
    }
}
