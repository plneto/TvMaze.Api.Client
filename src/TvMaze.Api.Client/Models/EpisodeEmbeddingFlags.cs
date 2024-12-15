using System;

namespace TvMaze.Api.Client.Models;

[Flags]
public enum EpisodeEmbeddingFlags
{
    None = 0,
    Show = 0b0001
}