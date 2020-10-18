namespace TodoBusiness.Exceptions
{
    public class UserBadRequestException : BadRequestException
    {
        public UserBadRequestException() : base("Incorrect data")
        {

        }
    }
}
