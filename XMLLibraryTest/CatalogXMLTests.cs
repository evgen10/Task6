using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyXMLLibrary.Abstract;
using MyXMLLibrary.Entities;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using MyXMLLibrary;
using System.Xml;
using XMLLibraryTest.Comparators;
using MyXMLLibrary.Exceptions;

namespace XMLLibraryTests
{
    [TestClass]
    public class CatalogXMLTests
    {
        private IEnumerable<ICatalogItem> GetItems()
        {
            List<ICatalogItem> items = new List<ICatalogItem>()
            {
                new Book
                {
                    Name = "One Hundred Years of Solitude",
                    PageCount=658,
                    PublicationPlace="RK",
                    Author = new  List<Author>
                    {
                        new Author { Name = "Gabriel García Márquez" },
                    },
                    PublicationYear=2018,
                    PublisherName="TOO BOOK",
                    Remark = "It's a book",
                    ISBN = "7-165-28221"
                },
                new Newspaper
                {
                    Name = "Time",
                    PageCount=30,
                    PublicationPlace="New York",
                    PublicationYear = 2018,
                    PublisherName = "TOO NEWSPAPER",
                    Number = "78",
                    Date = Convert.ToDateTime("2018 - 08 - 17"),
                    Remark = "It's a newspaper",
                    ISSN = "0317-8471"
                },
                new Patent
                {
                    Name = "Spaceship",
                    PageCount=100,
                    Author = new  List<Author>
                    {
                        new Author { Name = "Oscar Wilde" },
                        new Author { Name = "James Hetfield" },
                        new Author { Name = "Elon Musk" }
                    },
                    Country = "Russia",
                    RegistrationNamber = "1234-33-445",
                    FilingDate = Convert.ToDateTime("2014-01-17"),
                    PublicationDate = Convert.ToDateTime("2018-08-17"),
                    Remark = "It's a patent"
                }
            };

            return items;

        }

        private XElement GetXmlDocument()
        {
            return new XElement("catalog",
                            new XAttribute("unloadingTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            new XElement("book",
                                new XElement("name", "One Hundred Years of Solitude"),
                                new XElement("authors",
                                    new XElement("name", "Gabriel García Márquez")),
                                new XElement("publicationPlace", "RK"),
                                new XElement("publisherName", "TOO BOOK"),
                                new XElement("publicationYear", "2018"),
                                new XElement("pageCount", "658"),
                                new XElement("remark", "It's a book"),
                                new XElement("isbn", "7-165-28221")),
                            new XElement("newspaper",
                                new XElement("name", "Time"),
                                new XElement("publicationPlace", "New York"),
                                new XElement("publisherName", "TOO NEWSPAPER"),
                                new XElement("publicationYear", "2018"),
                                new XElement("pageCount", "30"),
                                new XElement("remark", "It's a newspaper"),
                                new XElement("number", "78"),
                                new XElement("date", "2018-08-17"),
                                new XElement("issn", "0317-8471")),
                            new XElement("patent",
                                new XElement("name", "Spaceship"),
                                new XElement("authors",
                                    new XElement("name", "Oscar Wilde"),
                                    new XElement("name", "James Hetfield"),
                                    new XElement("name", "Elon Musk")),
                                new XElement("country", "Russia"),
                                new XElement("registrationNamber", "1234-33-445"),
                                new XElement("filingDate", "2014-01-17"),
                                new XElement("publicationDate", "2018-08-17"),
                                new XElement("pageCount", "100"),
                                new XElement("remark", "It's a patent")));
        }

        private IEnumerable<ICatalogItem> GetItemsWithoutRequiredProperty()
        {
            return new List<ICatalogItem>()
            {
                new Book
                {
                    Name = "One Hundred Years of Solitude",
                    PageCount=658,
                    PublicationPlace="RK",
                    Author = new  List<Author>
                    {
                        new Author { Name = "Gabriel García Márquez" },
                    },
                    PublicationYear=2018,
                    PublisherName="TOO BOOK",
                    Remark = "It's a book",
                    ISBN = ""
                }

                };
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredProperiesException))]
        public void WriteWithRequiredPropertyException()
        {

            CatalogXML catalogXML = new CatalogXML();

            using (MemoryStream ms = new MemoryStream())
            {
                catalogXML.WriteTo(ms,GetItemsWithoutRequiredProperty());                
            }

            




        }

        [TestMethod]
        public void ReadXMLTest()
        {
            CatalogXML catalogXml = new CatalogXML();
            XElement xmlDocument = GetXmlDocument();

            using (MemoryStream sr = new MemoryStream())
            {
                xmlDocument.Save(sr);
                sr.Position = 0;
                List<ICatalogItem> result = catalogXml.ReadFrom(sr).ToList();

                Assert.IsTrue(new BookComparator().Compare((Book)result[0], new Book
                {
                    Name = "One Hundred Years of Solitude",
                    PageCount = 658,
                    PublicationPlace = "RK",
                    PublicationYear = 2018,
                    PublisherName = "TOO BOOK",
                    Remark = "It's a book",
                    ISBN = "7-165-28221"
                }) == 0);

                Assert.IsTrue(new NewspaperComparator().Compare((Newspaper)result[1], new Newspaper
                {
                    Name = "Time",
                    PageCount = 30,
                    PublicationPlace = "New York",
                    PublicationYear = 2018,
                    PublisherName = "TOO NEWSPAPER",
                    Number = "78",
                    Date = Convert.ToDateTime("2018 - 08 - 17"),
                    Remark = "It's a newspaper",
                    ISSN = "0317-8471"
                }) == 0);

                Assert.IsTrue(new PatentComparator().Compare((Patent)result[2], new Patent
                {
                    Name = "Spaceship",
                    PageCount = 100,
                    Country = "Russia",
                    RegistrationNamber = "1234-33-445",
                    FilingDate = Convert.ToDateTime("2014-01-17"),
                    PublicationDate = Convert.ToDateTime("2018-08-17"),
                    Remark = "It's a patent"
                }) == 0);
            }
        }

        [TestMethod]
        public void WriteElementTest()
        {
            CatalogXML catalogXml = new CatalogXML();

            using (MemoryStream ms = new MemoryStream())
            {
                catalogXml.WriteTo(ms, GetItems());
                ms.Position = 0;

                List<ICatalogItem> result = catalogXml.ReadFrom(ms).ToList();



                Assert.IsTrue(new BookComparator().Compare((Book)result[0], new Book
                {
                    Name = "One Hundred Years of Solitude",
                    PageCount = 658,
                    PublicationPlace = "RK",
                    PublicationYear = 2018,
                    PublisherName = "TOO BOOK",
                    Remark = "It's a book",
                    ISBN = "7-165-28221"
                }) == 0);

                Assert.IsTrue(new NewspaperComparator().Compare((Newspaper)result[1], new Newspaper
                {
                    Name = "Time",
                    PageCount = 30,
                    PublicationPlace = "New York",
                    PublicationYear = 2018,
                    PublisherName = "TOO NEWSPAPER",
                    Number = "78",
                    Date = Convert.ToDateTime("2018 - 08 - 17"),
                    Remark = "It's a newspaper",
                    ISSN = "0317-8471"
                }) == 0);

                Assert.IsTrue(new PatentComparator().Compare((Patent)result[2], new Patent
                {
                    Name = "Spaceship",
                    PageCount = 100,
                    Country = "Russia",
                    RegistrationNamber = "1234-33-445",
                    FilingDate = Convert.ToDateTime("2014-01-17"),
                    PublicationDate = Convert.ToDateTime("2018-08-17"),
                    Remark = "It's a patent"
                }) == 0);


            }





        }
    }
}
