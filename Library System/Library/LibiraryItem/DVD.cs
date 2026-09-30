using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LibiraryItem
{
    public class DVD : LibraryItem
    {
        public DVD(string catalogNumber, string title, int baseLateFee) 
            : base(catalogNumber, title, baseLateFee, 7, 2)
        {
        }
    }
}
