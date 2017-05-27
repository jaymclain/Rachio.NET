// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnixEpochDateTimeConverter.cs" company="HomeRun Software Systems">
//   Copyright (c) HomeRun Software Systems
// </copyright>
// <summary>
//   Defines the UnixEpochDateTimeConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rachio.NET.Service.Infrastructure
{
    public class UnixEpochDateTimeConverter
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public long Convert(DateTime date)
        {
           return (long)(date - Epoch).TotalMilliseconds;
        }

        public DateTime Convert(long millisecondsSinceEpoch)
        {
            return Epoch.AddMilliseconds(millisecondsSinceEpoch);
        }
    }
}
