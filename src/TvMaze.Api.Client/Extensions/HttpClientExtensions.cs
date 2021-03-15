using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TvMaze.Api.Client.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string url, Func<HttpResponseMessage, (bool Handled, T Result)> unsuccessfulResponseHandler = null)
        {
            using (var httpResponse = await httpClient.GetAsync(url))
            {
                if (!httpResponse.IsSuccessStatusCode)
                {
                    var handlerResult = unsuccessfulResponseHandler?.Invoke(httpResponse) ??
                                        DefaultUnsuccessfulResponseHandler<T>(httpResponse);
                    if (handlerResult.Handled)
                    {
                        return handlerResult.Result;
                    }

                    throw new UnexpectedResponseStatusException(httpResponse.StatusCode);
                }

                var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
        }

        private static (bool Handled, T Result) DefaultUnsuccessfulResponseHandler<T>(HttpResponseMessage response)
        {
            var resultType = typeof(T);
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    if (resultType.IsConstructedGenericType && resultType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        var emptyEnumerable = typeof(Enumerable).GetMethod(nameof(Enumerable.Empty)).MakeGenericMethod(typeof(T).GenericTypeArguments[0]).Invoke(null, null);
                        return (true, (T)emptyEnumerable);
                    }

                    return (true, default);
                default:
                    return (false, default);
            }
        }
    }
}
