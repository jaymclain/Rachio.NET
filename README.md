# Rachio.NET
Rachio.NET allows access to the Rachio API from .NET code.

To use this library, you must first obtain an API Access Token from the Rachio webapp. Instructions for obtaining your Access Token are available at https://rachio.readme.io/docs/authentication

Once you have obtained your unique API Access Token you can initialize a new ```RachioService``` by providing the token in the ```ServiceOptions``` when creating the service:

```var service = RachioService.Create(new ServiceOptions { AccessToken = "{Your Access Token}" });```

The ```RachioService``` provides the main interface to your Rachio devices, zones, schedules, etc.

See https://github.com/jaymclain/Rachio.NET/blob/master/src/Docs/Rachio.NET.Service.GeneratedXmlDoc.md for more information.
