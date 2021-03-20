using System;
using System.Collections.Generic;
using System.Linq;

namespace TvMaze.Api.Client.Extensions
{
    internal static class StringEnumerableExtensions
    {
        private const string EmbedKey = "embed";
        private const string EmbedArrayKey = EmbedKey + "[]";

        public static string ToEmbedQueryString(this IEnumerable<string> embedValues)
        {
            var embedValuesArray = embedValues.ToArray();

            if (embedValuesArray.Length == 1)
            {
                return EmbedKey + "=" + Uri.EscapeDataString(embedValuesArray.First());
            }

            return string.Join("&", embedValuesArray.Select(value => EmbedArrayKey + "=" + Uri.EscapeDataString(value)));
        }
    }
}