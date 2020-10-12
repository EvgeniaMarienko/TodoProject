using System;
using System.Collections.Generic;
using System.Text;

namespace TodoBuisness.Exceptions
{
    public class EmployeeBadRequestException : BadRequestException
    {
        public EmployeeBadRequestException() : base("Incorrect data")
        {

        }
    }
}
