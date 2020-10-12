using System.Net;

namespace TodoBusiness.Exceptions
{
    public class NotFoundException : TodoException
    {
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {

        }
    }
}
