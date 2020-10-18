namespace TodoBusiness.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int id) : base($"User with id {id} not found")
        {

        }
    }
}
