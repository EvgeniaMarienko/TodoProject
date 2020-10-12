using System;
using System.Collections.Generic;
using System.Text;

namespace TodoBuisness.Exceptions
{
    public class ProjectBadRequestException:BadRequestException
    {
        public ProjectBadRequestException() : base("Incorrect data")
        {

        }
    }
}
