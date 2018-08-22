using MyXMLLibrary.Abstract;
using MyXMLLibrary.Entities;
using MyXMLLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MyXMLLibrary.Parsers
{
    class PatentParser : IXMLParser
    {
        public ICatalogItem ParseFrom(XElement element)
        {
            if (element.Name == "patent")
            {                         
                
                Patent patent = new Patent()
                {
                    Name               = element.Element("name").Value,
                    Author             = element.Element("authors").Elements("name").Select(a => new Author { Name = a.Value }).ToList(),
                    Country            = element.Element("country").Value,
                    RegistrationNamber = element.Element("registrationNamber").Value,
                    PageCount          = XMLUtilite.ConvertToInt((element.Element("pageCount").Value)),
                    FilingDate         = XMLUtilite.ConvertToDateTime(element.Element("filingDate").Value),
                    PublicationDate    = XMLUtilite.ConvertToDateTime(element.Element("publicationDate").Value),
                    Remark             = element.Element("remark").Value

                };


                XMLUtilite.CheckFields(patent);

                return patent;
            }

            throw new ParseException($"Element {element.Name} is unknown to the parser");
        }
    }
}
