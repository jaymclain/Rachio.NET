namespace Rachio.NET.Service
{
    interface IRachioServiceProvider
    {
        Person Person();
        Person Person(string id);
    }
}
