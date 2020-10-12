using System;
using System.Collections.Generic;
using System.Text;

namespace TodoBuisness.Exceptions
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(int id) : base($"Employee with id {id} not found")
        {

        }
    }
}
