// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RachioEntitySerializer.cs" company="HomeRun Software Systems">
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
//   Defines the RachioEntitySerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Rachio.NET.Service.Infrastructure.Json;
using Rachio.NET.Service.Model;

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

        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public T DeserializeObject<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content, _entityConverters);
        }
    }
}
