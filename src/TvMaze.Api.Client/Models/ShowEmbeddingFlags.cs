using System;

namespace TvMaze.Api.Client.Models;

[Flags]
public enum ShowEmbeddingFlags : short
{
    None = 0,
    Episodes = 1,
    Cast = 2,
    PreviousEpisode = 4,
    NextEpisode = 8,
    Seasons = 16,
    Crew = 32,
    Images = 64
}