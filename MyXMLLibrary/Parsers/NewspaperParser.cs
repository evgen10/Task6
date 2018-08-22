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
    class NewspaperParser : IXMLParser
    {
        public ICatalogItem ParseFrom(XElement element)
        {
            if (element.Name == "newspaper")
            {      

                Newspaper newspaper = new Newspaper()
                {
                    Name             = element.Element("name").Value,
                    PublicationPlace = element.Element("publicationPlace").Value,
                    PublisherName    = element.Element("publisherName").Value,
                    PublicationYear  = XMLUtilite.ConvertToInt(element.Element("publicationYear").Value),
                    PageCount        = XMLUtilite.ConvertToInt(element.Element("pageCount").Value),
                    Remark           = element.Element("remark").Value,
                    ISSN             = element.Element("issn").Value,
                    Date             = XMLUtilite.ConvertToDateTime((element.Element("date").Value)),
                    Number           = element.Element("number").Value
                };

                XMLUtilite.CheckFields(newspaper);

                return newspaper;
            }

            throw new ParseException($"Element {element.Name} is unknown to the parser");
        }
    }
}
