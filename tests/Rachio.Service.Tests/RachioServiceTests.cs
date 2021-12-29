using System;
using Rachio.NET.Service;
using Xunit;

namespace Rachio.NETCore11.Service.UnitTests
{
    public class RachioServiceTests
    {
        [Fact]
        public void When_Created_Should_Succeed()
        {
            var service = RachioService.Create(new ServiceOptions { AccessToken = "{Your Access Token}" });
            var person = service.Person();

            Assert.NotNull(service);
            Assert.NotNull(person);
        }
    }
}
