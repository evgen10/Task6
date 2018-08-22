using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyXMLLibrary.Abstract
{
    interface IXMLParser
    {
        ICatalogItem ParseFrom(XElement element);

    }
}
