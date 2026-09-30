using Library.LibiraryItem;
using Library.Loan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Member_Type
{
    public class Member : Person
    {
        protected Member(int personId, string fullName, string phone, decimal Maxloans, int Discountpercentage)
            : base(personId, fullName, phone)
        {
            MaxLoans = Maxloans;
            DiscountPercentage = Discountpercentage;
        }
        public decimal MaxLoans { get; }
        public int DiscountPercentage { get;}
        private readonly List<Loan.Loan> _loan = [];
        public IReadOnlyList<Loan.Loan> Loan => _loan;

        public Loan.Loan Borrow(LibraryItem item)
        {
            if (item.IsWithDraw)
                throw new InvalidOperationException("Cannot Borrow The Item IsWitdraw");
            if (item.IsOnLoan)
                throw new InvalidOperationException("Cannot Borrow The Item IsOnLoan");
            int Active = 0;
            foreach(var Item in _loan)
            {
                if (Item.Status == LoanStatus.Borrowed)
                    Active ++;
            }
            if(Active>=MaxLoans)
                throw new InvalidOperationException(
              "Member has reached the maximum number of active loans.");
           Loan.Loan loan = new Loan.Loan(this,item);
            _loan.Add(loan);
            item.IsOnLoan = true;
            return loan;
        }
    }
}
