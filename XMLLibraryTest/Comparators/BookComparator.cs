using MyXMLLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLLibraryTest.Comparators
{
    class BookComparator : IComparer<Book>
    {


        public int Compare(Book x, Book y)
        {
            return x.Name == y.Name &&
            x.ISBN == y.ISBN &&       
            x.PageCount == y.PageCount &&
            x.PublicationPlace == y.PublicationPlace &&
            x.PublicationYear == y.PublicationYear &&
            x.PublisherName == y.PublisherName &&
            x.Remark == y.Remark ? 0 : 1;

      
            

        }

       

    }
}
