using MyXMLLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXMLLibrary.Entities
{
    public abstract class CatalogItem: ICatalogItem
    {
        public string Name { get; set; }
        public int? PageCount { get; set; }
        public string Remark { get; set; }
        
    }
}
