using System;
using System.Net;
using System.Net.Http;

namespace TvMaze.Api.Client.Exceptions
{
    public class UnexpectedResponseStatusException : HttpRequestException
    {
        public HttpStatusCode StatusCode { get; }

        public UnexpectedResponseStatusException(HttpStatusCode statusCode)
            : this($"Received unexpected response status \"{statusCode}\".", statusCode)
        {
        }

        public UnexpectedResponseStatusException(string message, HttpStatusCode statusCode, Exception innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}