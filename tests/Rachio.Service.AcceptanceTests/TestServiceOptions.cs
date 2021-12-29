using System.IO;
using Rachio.NET.Service;

namespace Rachio.NETCore11.Service.AcceptanceTests
{
    public class TestServiceOptions : ServiceOptions
    {
        public TestServiceOptions()
        {
           AccessToken = File.ReadAllText("AccessToken.txt");
        }
    }
}
