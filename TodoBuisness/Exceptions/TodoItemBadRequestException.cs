namespace TodoBusiness.Exceptions
{
    public class TodoItemBadRequestException : BadRequestException
    {
        public TodoItemBadRequestException() : base("Incorrect data")
        {

        }
    }
}
