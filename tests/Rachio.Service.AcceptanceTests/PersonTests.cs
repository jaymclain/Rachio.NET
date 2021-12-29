using Rachio.NET.Service;
using Xunit;

namespace Rachio.NETCore11.Service.AcceptanceTests
{
    public class PersonTests
    {
        [Fact]
        public void When_Invoked_Should_Get_CurrentPerson()
        {
            // Arrange
            var service = RachioService.Create(new TestServiceOptions());

            // Act
            var currentPerson = service.Person();

            // Assert
            Assert.NotNull(currentPerson);
            Assert.True(!string.IsNullOrEmpty(currentPerson.Id));
        }
    }
}
