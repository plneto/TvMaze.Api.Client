using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TvMaze.Api.Client.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string url)
        {
            var httpResponse = await httpClient.GetAsync(url);

            httpResponse.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
