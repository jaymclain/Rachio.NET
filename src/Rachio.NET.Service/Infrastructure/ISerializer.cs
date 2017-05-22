namespace Rachio.NET.Service.Infrastructure
{
    public interface ISerializer
    {
        string Serialize(object value);
        T DeserializeObject<T>(string content);
    }
}
