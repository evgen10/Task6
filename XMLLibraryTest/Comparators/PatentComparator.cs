using MyXMLLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLLibraryTest.Comparators
{
    class PatentComparator : IComparer<Patent>
    {
        public int Compare(Patent x, Patent y)
        {
            return x.Country == y.Country &&
                   x.FilingDate == y.FilingDate &&
                   x.Name == y.Name &&
                   x.PageCount == y.PageCount &&
                   x.PublicationDate == y.PublicationDate &&
                   x.RegistrationNamber == y.RegistrationNamber &&
                   x.Remark == y.Remark ? 0 : 1;
        }
    }
}
