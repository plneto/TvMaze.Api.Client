namespace TvMaze.Api.Client.Models
{
    public class WebChannel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Country Country { get; set; }

        public string OfficialSite { get; set; }
    }
}
