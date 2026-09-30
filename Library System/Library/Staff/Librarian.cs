using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Staff
{
    public class Librarian : Staff
    {
        public Librarian(int personId, string fullName, string phone, DateTime Hiredate, decimal Monthlysalary) 
            : base(personId, fullName, phone, Hiredate, Monthlysalary)
        {
        }

        public void ProccessReturn(Loan.Loan loan,DateTime ReturnDate)
        {
            loan.Returned(ReturnDate);
        }
        public void MarkAtLost(Loan.Loan loan)
        {
            loan.MarkAtLost();
        }

    }
}
