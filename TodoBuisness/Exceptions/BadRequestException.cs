using System.Net;

namespace TodoBuisness.Exceptions
{
    public class BadRequestException : TodoException
    {
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest)
        {

        }
    }
}
