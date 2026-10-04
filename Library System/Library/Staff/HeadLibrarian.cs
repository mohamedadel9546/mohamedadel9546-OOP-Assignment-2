using Library.LibiraryItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Staff
{
    public class HeadLibrarian : Staff
    {
        public HeadLibrarian(int personId, string fullName, string phone, DateTime Hiredate, decimal Monthlysalary) 
            : base(personId, fullName, phone, Hiredate, Monthlysalary+400)
        {
        }

        public void ChangeLateFee(LibraryItem item,decimal Amount)
        {
            item.ChangeLateFee(Amount);
        }

        public void IsWithDraw(LibraryItem item)
        {
            item.IsWidraw();
        }
        public void Restore(LibraryItem item)
        {
            item.Restore();
        }
    }
}
