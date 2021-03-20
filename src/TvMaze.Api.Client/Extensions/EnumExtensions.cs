using System;
using System.Collections.Generic;
using System.Linq;

namespace TvMaze.Api.Client.Extensions
{
    internal static class EnumExtensions
    {
        public static IEnumerable<T> GetSelectedFlags<T>(this T flags, T noneValue) where T : Enum
        {
            return Enum
                .GetValues(typeof(T))
                .OfType<T>()
                .Where(flag => !flag.Equals(noneValue) && flags.HasFlag(flag));
        }
    }
}