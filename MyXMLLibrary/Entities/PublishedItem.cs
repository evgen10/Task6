using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyXMLLibrary.Entities
{
    public abstract class PublishedItem : CatalogItem
    {
       
       public  string PublicationPlace { get; set; }
       public  string PublisherName { get; set; }
       public  int? PublicationYear { get; set; }
    }
}
