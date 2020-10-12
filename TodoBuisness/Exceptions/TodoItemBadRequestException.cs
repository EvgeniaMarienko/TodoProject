using System;
using System.Collections.Generic;
using System.Text;

namespace TodoBuisness.Exceptions
{
    public class TodoItemBadRequestException:BadRequestException
    {
        public TodoItemBadRequestException() : base("Incorrect data")
        {

        }
    }
}
