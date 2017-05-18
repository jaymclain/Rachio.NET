namespace Rachio.NET.Service
{
    public class RachioService
    {
        private const string PersonEntity = "person";
        private const string DeviceEntity = "device";
        private const string InfoAction = "info";

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
    }
}
