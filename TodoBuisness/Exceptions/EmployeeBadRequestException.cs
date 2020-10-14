namespace TodoBusiness.Exceptions
{
    public class EmployeeBadRequestException : BadRequestException
    {
        public EmployeeBadRequestException() : base("Incorrect data")
        {

        }
    }
}
