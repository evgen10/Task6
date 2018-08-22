using System.Linq;
using System.Xml;
using MyXMLLibrary.Abstract;
using MyXMLLibrary.Entities;
using System.Xml.Linq;
using MyXMLLibrary.Exceptions;

namespace MyXMLLibrary.Writers
{
    class PatentXMLWriter : IXMLWriter
    {
        public void Write(XmlWriter xmlWriter, ICatalogItem item)
        {

            Patent patent = item as Patent;

            if (patent == null)
            {
                throw new WriteException($"For {item.GetType().Name}, no writing format is defined");
            }

            XMLUtilite.CheckFields(patent);            

            XElement xPatent = new XElement("patent",
                                 new XElement("name", patent.Name),
                                 new XElement("authors", patent.Author?.Select(a => 
                                     new XElement("name", a.Name))),
                                 new XElement("country", patent.Country),
                                 new XElement("registrationNamber", patent.RegistrationNamber),
                                 new XElement("filingDate", patent.FilingDate.Value.ToString("yyyy-MM-dd")),
                                 new XElement("publicationDate", patent.PublicationDate.Value.ToString("yyyy-MM-dd")),
                                 new XElement("pageCount", patent.PageCount),
                                 new XElement("remark", patent.Remark));


            xPatent.WriteTo(xmlWriter);
        }
    }
}
