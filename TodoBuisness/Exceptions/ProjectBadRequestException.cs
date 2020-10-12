namespace TodoBuisness.Exceptions
{
    public class ProjectBadRequestException : BadRequestException
    {
        public ProjectBadRequestException() : base("Incorrect data")
        {

        }
    }
}
