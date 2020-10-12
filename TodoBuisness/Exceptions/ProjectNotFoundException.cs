using System;
using System.Collections.Generic;
using System.Text;

namespace TodoBuisness.Exceptions
{
    public class ProjectNotFoundException:NotFoundException
    {
        public ProjectNotFoundException(int id) : base($"Project with id {id} not found")
        {

        }
    }
}
