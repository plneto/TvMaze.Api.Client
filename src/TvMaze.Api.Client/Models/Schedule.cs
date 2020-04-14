using System.Collections.Generic;

namespace TvMaze.Api.Client.Models
{
    public class Schedule
    {
        public string Time { get; set; }
        
        public List<string> Days { get; set; }
    }
}
