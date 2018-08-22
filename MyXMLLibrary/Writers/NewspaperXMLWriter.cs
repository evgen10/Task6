using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MyXMLLibrary.Abstract;
using MyXMLLibrary.Entities;
using System.Xml.Linq;
using MyXMLLibrary.Exceptions;

namespace MyXMLLibrary.Writers
{
    class NewspaperXMLWriter : IXMLWriter
    {
        public void Write(XmlWriter xmlWriter, ICatalogItem item)
        {
            Newspaper newspaper = item as Newspaper;

            if (newspaper == null)
            {
                throw new WriteException($"For {item.GetType().Name}, no writing format is defined");
            }

            XMLUtilite.CheckFields(newspaper);


            XElement xNewspaper = new XElement("newspaper",
                                 new XElement("name", newspaper.Name),
                                 new XElement("publicationPlace", newspaper.PublicationPlace),
                                 new XElement("publisherName", newspaper.PublisherName),
                                 new XElement("publicationYear", newspaper.PublicationYear),
                                 new XElement("pageCount", newspaper.PageCount),
                                 new XElement("remark", newspaper.Remark),
                                 new XElement("number", newspaper.Number),
                                 new XElement("date", newspaper.Date.Value.ToString("yyyy-MM-dd")),
                                 new XElement("issn", newspaper.ISSN));

            xNewspaper.WriteTo(xmlWriter);
        }
    }
}
