namespace Rachio.NET.Service.Infrastructure
{
    public interface ISerializer
    {
        T DeserializeObject<T>(string content);
    }
}
