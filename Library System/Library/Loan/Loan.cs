
using Library.LibiraryItem;
using Library.Member_Type;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Library.Loan
{
    public class Loan
    {
        public Loan(Member member
            , LibraryItem libraryItem)
        {
            LoanId = new Guid();
            BorrowDate = DateTime.Now;
            DueDate = BorrowDate.AddDays(libraryItem.LoanPeriod);
            Member = member;
            Libraryitem = libraryItem;
            Status = LoanStatus.Borrowed;
        }

        public Guid LoanId { get; }
        public DateTime BorrowDate { get; }
        public DateTime DueDate { get; }
        public DateTime ReturnDate { get; private set; }
        public Member Member { get; }
        public LibraryItem Libraryitem { get;  }
        public LoanStatus Status { get;private set; }

        public void MarkAtLost()
        {
            if(Status!=LoanStatus.Borrowed)
                throw new InvalidOperationException(
                   "Only borrowed loans can be marked as lost.");
            Status = LoanStatus.Lost;
        }

        public void Returned(DateTime Returnedate)
        {
            if(Status!=LoanStatus.Borrowed)
                throw new InvalidOperationException(
                "Only borrowed loans can be marked as Returned.");
            if(Returnedate < BorrowDate)
                throw new InvalidOperationException(
            "Cannot ReturnedDate Ealier BorrowDate");
            Status = LoanStatus.Returned;
            ReturnDate = Returnedate;
            Libraryitem.IsOnLoan= false;
        }

        public decimal LateFee
        {
            get
            {
                int LateDays = (ReturnDate - DueDate).Days;
                decimal LateFee = LateDays * Libraryitem.GetDailyLateFee();
                decimal Discount = LateFee * (Member.DiscountPercentage / 100);
                return LateFee - Discount;
            }
        }

    }
}
