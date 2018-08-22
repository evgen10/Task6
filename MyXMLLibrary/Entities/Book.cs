using MyXMLLibrary.Abstract;
using MyXMLLibrary.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXMLLibrary.Entities
{
    public class Book : PublishedItem
    {      
        
        public IEnumerable<Author> Author { get; set; }   

        [Required]
        public string ISBN { get; set; }

    }
}
