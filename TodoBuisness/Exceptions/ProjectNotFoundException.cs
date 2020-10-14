namespace TodoBusiness.Exceptions
{
    public class ProjectNotFoundException : NotFoundException
    {
        public ProjectNotFoundException(int id) : base($"Project with id {id} not found")
        {

        }
    }
}
