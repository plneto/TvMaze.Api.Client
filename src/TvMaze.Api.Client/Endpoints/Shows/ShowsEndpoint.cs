using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints.Shows;

public class ShowsEndpoint : IShowsEndpoint
{
    private readonly TvMazeHttpClient _httpClient;

    public ShowsEndpoint(TvMazeHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc />
    public Task<Show?> GetShowMainInformationAsync(int showId, ShowEmbeddingFlags embeddings = ShowEmbeddingFlags.None)
    {
        if (showId <= 0)
        {
            throw new ArgumentException(nameof(showId));
        }

        return _httpClient.GetAsync<Show>(ShowEmbeddings.AddQueryStringToUrl($"shows/{showId}", embeddings));
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Episode>> GetShowEpisodeListAsync(int showId, bool includeSpecials = false)
    {
        if (showId <= 0)
        {
            throw new ArgumentException(nameof(showId));
        }

        var url = $"shows/{showId}/episodes";
        if (includeSpecials)
        {
            url = url.SetQueryParam(TvMazeQueryParameters.Specials, TvMazeQueryParameters.ValueTrue);
        }

        var response = await _httpClient.GetAsync<IEnumerable<Episode>>(url);

        return response ?? [];
    }

    /// <inheritdoc />
    public Task<Episode?> GetEpisodeByNumberAsync(int showId, int season, int episodeNumber)
    {
        if (showId <= 0)
        {
            throw new ArgumentException(nameof(showId));
        }

        if (season <= 0)
        {
            throw new ArgumentException(nameof(season));
        }

        if (episodeNumber <= 0)
        {
            throw new ArgumentException(nameof(episodeNumber));
        }

        return _httpClient.GetAsync<Episode>($"shows/{showId}/episodebynumber?season={season}&number={episodeNumber}");
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Episode>> GetEpisodesByDateAsync(int showId, DateTime date)
    {
        if (showId <= 0)
        {
            throw new ArgumentException(nameof(showId));
        }

        if (date == default)
        {
            throw new ArgumentException(nameof(date));
        }

        var response = await _httpClient.GetAsync<IEnumerable<Episode>>($"shows/{showId}/episodesbydate?date={date:yyyy-MM-dd}");
        
        return response ?? [];
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Season>> GetShowSeasonsAsync(int showId)
    {
        if (showId <= 0)
        {
            throw new ArgumentException(nameof(showId));
        }

        var response = await _httpClient.GetAsync<IEnumerable<Season>>($"shows/{showId}/seasons");
        
        return response ?? [];
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Episode>> GetSeasonEpisodesAsync(int seasonId)
    {
        if (seasonId <= 0)
        {
            throw new ArgumentException(nameof(seasonId));
        }

        var response = await _httpClient.GetAsync<IEnumerable<Episode>>($"seasons/{seasonId}/episodes");
        
        return response ?? [];
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Cast>> GetShowCastAsync(int showId)
    {
        if (showId <= 0)
        {
            throw new ArgumentException(nameof(showId));
        }

        var response = await _httpClient.GetAsync<IEnumerable<Cast>>($"shows/{showId}/cast");
        
        return response ?? [];
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Crew>> GetShowCrewAsync(int showId)
    {
        if (showId <= 0)
        {
            throw new ArgumentException(nameof(showId));
        }

        var response = await _httpClient.GetAsync<IEnumerable<Crew>>($"shows/{showId}/crew");
        
        return response ?? [];
    }

    public async Task<IEnumerable<ShowAlias>> GetShowAkasAsync(int showId)
    {
        if (showId <= 0)
        {
            throw new ArgumentException(nameof(showId));
        }

        var response = await _httpClient.GetAsync<IEnumerable<ShowAlias>>($"shows/{showId}/akas");
        
        return response ?? [];
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ShowImage>> GetShowImagesAsync(int showId)
    {
        if (showId <= 0)
        {
            throw new ArgumentException(nameof(showId));
        }

        var response = await _httpClient.GetAsync<IEnumerable<ShowImage>>($"shows/{showId}/images");
        
        return response ?? [];
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Show>> GetShowsAsync(int page)
    {
        if (page < 0)
        {
            throw new ArgumentException(nameof(page));
        }

        var response = await _httpClient.GetAsync<IEnumerable<Show>>("shows".SetQueryParam(TvMazeQueryParameters.Page, page));
        
        return response ?? [];
    }
}