using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXMLLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class RequiredAttribute:Attribute
    {
    }
}
