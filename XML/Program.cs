using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyXMLLibrary.Entities;
using System.Xml;
using MyXMLLibrary.Abstract;
using System.Xml.Linq;
using System.IO;
using MyXMLLibrary;
using MyXMLLibrary.Exceptions;

namespace XML
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu();
            Console.WriteLine();
            Console.Read();
        }


        static IEnumerable<ICatalogItem> GetItems()
        {
            List<ICatalogItem> books = new List<ICatalogItem>()
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
                    Date = DateTime.Now,
                    Remark = "It's a newspaper",
                    ISSN = "0317-8471"
                },
                new Book
                {
                    Name = "A Brief History Of Time",
                    PageCount=847,
                    PublicationPlace="RF",
                    Author = new  List<Author>
                    {
                        new Author { Name = "Stephen Hawking" }
                    },
                   PublicationYear=2014,
                    PublisherName="TOO BOOK",
                    Remark = "It's a book",
                    ISBN = "4-495-28461"
                },
                new Book
                {
                    Name = "The Picture of Dorian Gray",
                    PageCount=420,
                    PublicationPlace="USA",
                    Author = new  List<Author>
                    {
                        new Author { Name = "Oscar Wilde" }
                    },
                    PublicationYear=2013,
                    PublisherName="TOO BOOK",
                    Remark = "It's a book",
                    ISBN = "7-523-297641"
                },
                new Newspaper
                {
                    Name = "Guardian",
                    PageCount=44,
                    PublicationPlace="USA",
                    PublicationYear = 2018,
                    PublisherName = "TOO NEWSPAPER",
                    Number = "18",
                    Date = DateTime.Now,
                    Remark = "It's a newspaper",
                    ISSN = "0475-7853"
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
                    FilingDate = DateTime.Now.AddYears(-5).AddMonths(5),
                    PublicationDate =  DateTime.Now,
                    Remark = "It's a patent"
                }
            };

            return books;
        }

        static CatalogXML cataolg = new CatalogXML();

        static void ReadXML()
        {
            List<ICatalogItem> items = new List<ICatalogItem>();

            using (Stream fs = new FileStream("Contacts.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    items = cataolg.ReadFrom(fs).ToList();
                    ItemViewer itemViewer = new ItemViewer();
                    itemViewer.ShowItems(items);

                }
                catch (RequiredProperiesException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ParseException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (WriteException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (XmlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        static void WriteXML()
        {
            using (Stream fs = new FileStream("Contacts.xml", FileMode.OpenOrCreate))
            {
                try
                {

                    CatalogXML cataolg = new CatalogXML();
                    cataolg.WriteTo(fs, GetItems());

                }
                catch (RequiredProperiesException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ParseException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (WriteException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (XmlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("Press 1 to write data to XML");
            Console.WriteLine("Press 2 to read data from XML");

            int key = int.Parse(Console.ReadLine());

            switch (key)
            {

                case 1:
                    {
                        WriteXML();                        
                        break;
                    }
                case 2:
                    {
                        ReadXML();
                        break;
                    }

                default:
                    break;
            }

        }



    }
}
