using System.Collections.Generic;
using TvMaze.Api.Client.Extensions;

namespace TvMaze.Api.Client.Models
{
    public class ShowEmbeddings
    {
        public const string EmbeddingValueEpisodes = "episodes";
        public const string EmbeddingValueCast = "cast";
        public const string EmbeddingValuePreviousEpisode = "previousepisode";
        public const string EmbeddingValueNextEpisode = "nextepisode";

        public static string AddQueryStringToUrl(string url, ShowEmbeddingFlags embeddingFlags)
        {
            if (embeddingFlags == ShowEmbeddingFlags.None)
            {
                return url;
            }

            var embeddingValues = new List<string>();

            if (embeddingFlags.HasFlag(ShowEmbeddingFlags.Episodes))
            {
                embeddingValues.Add(EmbeddingValueEpisodes);
            }

            if (embeddingFlags.HasFlag(ShowEmbeddingFlags.Cast))
            {
                embeddingValues.Add(EmbeddingValueCast);
            }

            if (embeddingFlags.HasFlag(ShowEmbeddingFlags.PreviousEpisode))
            {
                embeddingValues.Add(EmbeddingValuePreviousEpisode);
            }

            if (embeddingFlags.HasFlag(ShowEmbeddingFlags.NextEpisode))
            {
                embeddingValues.Add(EmbeddingValueNextEpisode);
            }

            return url + (url.Contains("?") ? "&" : "?") + embeddingValues.ToEmbedQueryString();
        }

        public IEnumerable<Episode> Episodes { get; set; }

        public IEnumerable<Cast> Cast { get; set; }
        
        public Episode PreviousEpisode { get; set; }

        public Episode NextEpisode { get; set; }
    }
}