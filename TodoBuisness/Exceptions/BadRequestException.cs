using System.Net;

namespace TodoBusiness.Exceptions
{
    public class BadRequestException : TodoException
    {
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest)
        {

        }
    }
}
