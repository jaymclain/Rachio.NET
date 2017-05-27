using System;

namespace Rachio.NET.Service
{
    public class RachioServiceProviderException : Exception
    {
        public RachioServiceProviderException(string code, string message)
            : base(message)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
