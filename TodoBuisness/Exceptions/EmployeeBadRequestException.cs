namespace TodoBuisness.Exceptions
{
    public class EmployeeBadRequestException : BadRequestException
    {
        public EmployeeBadRequestException() : base("Incorrect data")
        {

        }
    }
}
