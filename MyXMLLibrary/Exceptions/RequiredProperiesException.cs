using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXMLLibrary.Exceptions
{
    public class RequiredProperiesException : Exception
    {
        public RequiredProperiesException(string message) : base(message)
        {
        }
    }
}
