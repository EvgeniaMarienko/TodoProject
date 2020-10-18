using System.Net;

namespace TodoWeb.Models
{
    public class ErrorResponseModel
    {
        public string ErrorMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
