using System;

namespace TvMaze.Api.Client.Models
{
    [Flags]
    public enum ShowEmbeddingFlags
    {
        None = 0,
        Episodes = 0b0001,
        Cast = 0b0010,
        PreviousEpisode = 0b0100,
        NextEpisode = 0b1000
    }
}