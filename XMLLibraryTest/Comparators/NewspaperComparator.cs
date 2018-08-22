using MyXMLLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLLibraryTest.Comparators
{
    class NewspaperComparator : IComparer<Newspaper>
    {
        public int Compare(Newspaper x, Newspaper y)
        {

            int re=
       
            x.Name == y.Name &&
           x.PageCount == y.PageCount &&
           x.PublicationPlace == y.PublicationPlace &&
           x.PublicationYear == y.PublicationYear &&
           x.PublisherName == y.PublisherName &&
           x.Date == y.Date &&
           x.Number ==y.Number &&
           x.Remark == y.Remark ? 0 : 1;

            return re;
        }
    }
}
