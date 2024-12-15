using Flurl;
using System.Collections.Generic;
using System.Linq;
using TvMaze.Api.Client.Extensions;

namespace TvMaze.Api.Client.Models;

public class EpisodeEmbeddings
{
    private static readonly IReadOnlyDictionary<EpisodeEmbeddingFlags, string> EmbeddingValueMapping =
        new Dictionary<EpisodeEmbeddingFlags, string>
        {
            {EpisodeEmbeddingFlags.Show, "show"}
        };

    public static string AddQueryStringToUrl(string url, EpisodeEmbeddingFlags embeddingFlags)
    {
        if (embeddingFlags == EpisodeEmbeddingFlags.None)
        {
            return url;
        }

        return url.SetQueryParam(TvMazeQueryParameters.EmbedArray, embeddingFlags
            .GetSelectedFlags(EpisodeEmbeddingFlags.None)
            .Select(flag => EmbeddingValueMapping[flag]));
    }

    public Show? Show { get; set; }
}