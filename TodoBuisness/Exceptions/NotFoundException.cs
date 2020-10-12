using System.Net;

namespace TodoBuisness.Exceptions
{
    public class NotFoundException : TodoException
    {
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {

        }
    }
}
