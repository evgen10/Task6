using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyXMLLibrary.Abstract
{
    interface IXMLWriter
    {        
        void Write(XmlWriter xmlWriter,ICatalogItem item);

    }
}
