using System;
using System.Net;

namespace TodoBuisness.Exceptions
{
    public class TodoException : Exception
    {
        public TodoException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; private set; }
    }
}
