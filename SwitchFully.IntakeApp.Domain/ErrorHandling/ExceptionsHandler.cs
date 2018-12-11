using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.ErrorHandling
{
    public class ExceptionsHandler : ApplicationException
    {

        public ExceptionsHandler(string type, string message) : base( type + " Exeption: " + message)
        { }
    }
}
