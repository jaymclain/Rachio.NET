using Rachio.NET.Service;
using System.IO;
using Xunit;

namespace Rachio.NETCore11.Service.AcceptanceTests
{
    public class PersonTests
    {
        [Fact]
        public void When_Invoked_Should_Get_Info()
        {
            var accessToken = File.ReadAllText("AccessToken.txt");
            var service = RachioService.Create(new ServiceOptions { AccessToken = accessToken });
            var currentPerson = service.Person();
            var person = service.Person(currentPerson.Id);
        }
    }
}
