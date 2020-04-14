using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Api.Client.Models;

namespace TvMaze.Api.Client.Endpoints
{
    public interface ISearchEndpoint
    {
        Task<IEnumerable<ShowSearchResult>> ShowSearchAsync(string query);
    }
}
