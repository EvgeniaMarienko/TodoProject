namespace TodoBuisness.Exceptions
{
    public class TodoItemNotFoundException : NotFoundException
    {
        public TodoItemNotFoundException(int id) : base($"TodoItem with id {id} not found")
        {

        }
    }
}
