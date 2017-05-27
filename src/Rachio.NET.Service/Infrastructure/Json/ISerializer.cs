// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISerializer.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the ISerializer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Rachio.NET.Service.Infrastructure.Json
{
    public interface ISerializer
    {
        string Serialize(object value);
        T DeserializeObject<T>(string content);
    }
}
