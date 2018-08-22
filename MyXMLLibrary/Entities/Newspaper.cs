using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyXMLLibrary.Abstract;
using MyXMLLibrary.Attributes;

namespace MyXMLLibrary.Entities
{
    public class Newspaper : PublishedItem
    {
        [Required]
        public string Number { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        public string ISSN { get; set; }

    }
}
