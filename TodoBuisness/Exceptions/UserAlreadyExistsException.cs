namespace TodoBusiness.Exceptions
{
    public class UserAlreadyExistsException : BadRequestException
    {
        public UserAlreadyExistsException(string email) : base($"User with email {email} already exists")
        {

        }
    }
}
