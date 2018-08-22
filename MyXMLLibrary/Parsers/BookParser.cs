using MyXMLLibrary.Abstract;
using MyXMLLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using System.Xml;
using MyXMLLibrary.Exceptions;

namespace MyXMLLibrary.Parsers
{
    class BookParser : IXMLParser
    {
        
        public ICatalogItem ParseFrom(XElement element)
        {
            if (element.Name == "book")
            {                       
                Book book = new Book()
                {
                    Name             = element.Element("name").Value,
                    Author           = element.Element("authors").Elements().Select(a => new Author { Name = a.Value }).ToList(),
                    PublicationPlace = element.Element("publicationPlace").Value,
                    PublisherName    = element.Element("publisherName").Value,
                    PublicationYear  = XMLUtilite.ConvertToInt(element.Element("publicationYear").Value),
                    PageCount        = XMLUtilite.ConvertToInt(element.Element("pageCount").Value),
                    Remark           = element.Element("remark").Value,
                    ISBN             = element.Element("isbn").Value
                };

                XMLUtilite.CheckFields(book);

                return book;
            }

            throw new ParseException($"Element {element.Name} is unknown to the parser");

        }
    }
}
