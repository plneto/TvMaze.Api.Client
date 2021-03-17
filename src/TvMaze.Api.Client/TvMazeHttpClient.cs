using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using TvMaze.Api.Client.Exceptions;

namespace TvMaze.Api.Client
{
    public class TvMazeHttpClient
    {
        private readonly FlurlClient _flurlClient;

        public TvMazeHttpClient(FlurlClient flurlClient)
        {
            _flurlClient = flurlClient;
        }

        public async Task<T> GetAsync<T>(string url, Func<T> notFoundResponseHandler = null)
        {
            using (var httpResponse = await _flurlClient.Request(url).GetAsync())
            {
                switch (httpResponse.StatusCode)
                {
                    case (int)HttpStatusCode.OK:
                        return await httpResponse.GetJsonAsync<T>();

                    case (int)HttpStatusCode.NotFound:
                        var handler = notFoundResponseHandler ?? DefaultNotFoundResponseHandler<T>();

                        return handler.Invoke();

                    default:
                        throw new UnexpectedResponseStatusException((HttpStatusCode)httpResponse.StatusCode); ;
                }
            }
        }

        private static Func<T> DefaultNotFoundResponseHandler<T>()
        {
            var resultType = typeof(T);

            if (resultType.IsConstructedGenericType && resultType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var emptyEnumerable = typeof(Enumerable)
                    .GetMethod(nameof(Enumerable.Empty))
                    .MakeGenericMethod(typeof(T).GenericTypeArguments[0])
                    .Invoke(null, null);

                return () => (T)emptyEnumerable;
            }

            return () => default;
        }
    }
}
