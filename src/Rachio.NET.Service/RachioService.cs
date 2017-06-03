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
