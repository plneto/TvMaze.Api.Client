using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Search;

public class SearchEndpoint : ISearchEndpoint
{
    private readonly TvMazeHttpClient _httpClient;

    public SearchEndpoint(TvMazeHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ShowSearchResult>> ShowSearchAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentNullException(nameof(query));
        }

        var response = await _httpClient.GetAsync<IEnumerable<ShowSearchResult>>($"search/shows?q={query}");

        return response ?? [];
    }

    /// <inheritdoc />
    public Task<Show?> ShowSingleSearchAsync(string query, ShowEmbeddingFlags embeddings = ShowEmbeddingFlags.None)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentNullException(nameof(query));
        }

        return _httpClient.GetAsync<Show>(ShowEmbeddings.AddQueryStringToUrl($"singlesearch/shows?q={query}", embeddings));
    }
}