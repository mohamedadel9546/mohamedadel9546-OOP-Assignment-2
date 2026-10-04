using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LibiraryItem
{
    public class Book : LibraryItem
    {
        public Book(string catalogNumber, string title, int baseLateFee) 
            : base(catalogNumber, title, baseLateFee, 21, 1)
        {
        }
    }
}
