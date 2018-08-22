using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyXMLLibrary.Abstract;
using MyXMLLibrary.Attributes;

namespace MyXMLLibrary.Entities
{
    public class Patent : CatalogItem
    {
        public IEnumerable<Author> Author { get; set; }

        public string Country { get; set; }

        [Required]
        public string RegistrationNamber { get; set; }
        [Required]
        public DateTime? FilingDate { get; set; }
       
        public DateTime? PublicationDate { get; set; }



    }
}
