using System.Collections.Generic;
using TvMaze.Api.Client.Extensions;

namespace TvMaze.Api.Client.Models
{
    public class EpisodeEmbeddings
    {
        public const string EmbeddingValueShow = "show";

        public static string AddQueryStringToUrl(string url, EpisodeEmbeddingFlags embeddingFlags)
        {
            if (embeddingFlags == EpisodeEmbeddingFlags.None)
            {
                return url;
            }

            var embeddingValues = new List<string>();

            if (embeddingFlags.HasFlag(EpisodeEmbeddingFlags.Show))
            {
                embeddingValues.Add(EmbeddingValueShow);
            }

            return url + (url.Contains("?") ? "&" : "?") + embeddingValues.ToEmbedQueryString();
        }

        public Show Show { get; set; }
    }
}