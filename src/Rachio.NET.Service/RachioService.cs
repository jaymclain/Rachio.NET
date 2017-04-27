namespace Rachio.NET.Service
{
    public class RachioService
    {
        private readonly IRachioServiceProvider _serviceProvider;

        public static RachioService Create(ServiceOptions options)
        {
            return new RachioService(options);
        }

        public RachioService(ServiceOptions serviceOptions)
        {
            _serviceProvider = new RachioServiceProvider(serviceOptions);
        }

        public Person Person()
        {
            var current = _serviceProvider.Person();
            return Person(current.Id);
        }

        public Person Person(string id)
        {
            return _serviceProvider.Person(id);
        }
    }
}
