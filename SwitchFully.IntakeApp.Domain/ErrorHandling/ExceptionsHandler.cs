using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Domain.ErrorHandling
{
    public class ExceptionsHandler : ApplicationException
    {

        public ExceptionsHandler(Type type,string message) : base(type.ToString() + " Exeption: " + message)
        { }
    }
}
