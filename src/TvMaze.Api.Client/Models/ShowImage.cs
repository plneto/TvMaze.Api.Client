namespace TvMaze.Api.Client.Models;

public class ShowImage
{
    public long Id { get; set; }

    public ShowImageType? Type { get; set; }

    public bool Main { get; set; }

    public ShowImageResolutions? Resolutions { get; set; }
}