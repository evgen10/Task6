using MyXMLLibrary.Abstract;
using MyXMLLibrary.Attributes;
using MyXMLLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using MyXMLLibrary.Exceptions;

namespace MyXMLLibrary.Writers
{
    class BookXMLWriter : IXMLWriter
    {
        public void Write(XmlWriter xmlWriter, ICatalogItem item)
        {
            Book book = item as Book;

            if (book == null)
            {
                throw new WriteException($"For {item.GetType().Name}, no writing format is defined");
            }

            XMLUtilite.CheckFields(book);

            XElement xBook = new XElement("book",
                                 new XElement("name", book.Name),
                                 new XElement("authors", book.Author?.Select(a =>
                                      new XElement("name", a.Name))),
                                 new XElement("publicationPlace", book.PublicationPlace),
                                 new XElement("publisherName", book.PublisherName),
                                 new XElement("publicationYear", book.PublicationYear),
                                 new XElement("pageCount", book.PageCount),
                                 new XElement("remark", book.Remark),
                                 new XElement("isbn", book.ISBN));

            xBook.WriteTo(xmlWriter);

        }



    }
}
