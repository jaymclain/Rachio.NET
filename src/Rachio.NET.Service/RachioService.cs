// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RachioService.cs" company="HomeRun Software Systems">
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
//   Defines the RachioService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using Rachio.NET.Service.Model;

namespace Rachio.NET.Service
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The main service for interaction with the Rachio Smart Sprinkler Controller
    /// </summary>
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

        /// <summary>
        /// Creates the Rachio Smart Sprinkler Controller communications service
        /// </summary>
        /// <param name="options">Options for the RachioService</param>
        /// <returns>The RachioService</returns>
        /// <code>
        ///     var service = RachioService.Create(new ServiceOptions { AccessToken = "{Your Access Token}" });
        /// </code>
        public static RachioService Create(ServiceOptions options)
        {
            return new RachioService(options);
        }

        /// <summary>
        /// Retrieves the information for the person currently logged in.
        /// </summary>
        /// <returns>The Person entity</returns>
        /// <code>
        ///     var service = RachioService.Create(new ServiceOptions { AccessToken = "{Your Access Token}" });
        ///     var person = service.Person();
        /// </code>
        public Person Person()
        {
            // person/info
            var current = _serviceProvider.GetAsync<Person>(PersonEntity, action: InfoAction).Result;
            return Person(current.Id);
        }

        /// <summary>
        /// Retrieves the information for a specific person
        /// </summary>
        /// <param name="id">A unique person id</param>
        /// <returns>The Person entity</returns>
        public Person Person(string id)
        {
            // person/{id}
            return _serviceProvider.GetAsync<Person>(PersonEntity, id).Result;
        }

        /// <summary>
        /// Retrieve the information for a specific device
        /// </summary>
        /// <param name="id">A unique device id</param>
        /// <returns>The Device entity</returns>
        public Device Device(string id)
        {
            // device/{id}
            return _serviceProvider.GetAsync<Device>(DeviceEntity, id).Result;
        }

        /// <summary>
        /// Retrieves the information for a specific zone
        /// </summary>
        /// <param name="id">A unique zone id</param>
        /// <returns>The Zone entity</returns>
        public Zone Zone(string id)
        {
            return _serviceProvider.GetAsync<Zone>(ZoneEntity, id).Result;
        }
    }
}
