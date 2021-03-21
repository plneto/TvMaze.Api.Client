using System.Collections.Generic;
using System.Linq;
using Flurl;
using TvMaze.Api.Client.Extensions;

namespace TvMaze.Api.Client.Models
{
    public class ShowEmbeddings
    {
        private static readonly IReadOnlyDictionary<ShowEmbeddingFlags, string> EmbeddingValueMapping =
            new Dictionary<ShowEmbeddingFlags, string>
            {
                {ShowEmbeddingFlags.Cast, "cast"},
                {ShowEmbeddingFlags.Episodes, "episodes"},
                {ShowEmbeddingFlags.PreviousEpisode, "previousepisode"},
                {ShowEmbeddingFlags.NextEpisode, "nextepisode"}
            };

        public static Url AddQueryStringToUrl(Url url, ShowEmbeddingFlags embeddingFlags)
        {
            if (embeddingFlags == ShowEmbeddingFlags.None)
            {
                return url;
            }

            return url.SetQueryParam(TvMazeQueryParameters.EmbedArray, embeddingFlags
                .GetSelectedFlags(ShowEmbeddingFlags.None)
                .Select(flag => EmbeddingValueMapping[flag]));
        }

        public IEnumerable<Episode> Episodes { get; set; }

        public IEnumerable<Cast> Cast { get; set; }

        public Episode PreviousEpisode { get; set; }

        public Episode NextEpisode { get; set; }
    }
}