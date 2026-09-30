using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LibiraryItem
{
    public class Magazin : LibraryItem
    {
        public Magazin(string catalogNumber, string title, int baseLateFee) 
            : base(catalogNumber, title, baseLateFee, 3, .5m)
        {
        }
    }
}
