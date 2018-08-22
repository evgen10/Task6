using MyXMLLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLLibraryTest.Comparators
{
    class AuthorComparator : IComparer<Author>
    {
        public int Compare(Author x, Author y)
        {
            return x.Name == y.Name ? 0 : 1;
        }
    }
}
