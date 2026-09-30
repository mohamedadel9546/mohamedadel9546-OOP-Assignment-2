using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library.LibiraryItem
{
    public class LibraryItem
    {
        protected LibraryItem(string catalogNumber, string title, decimal baseLateFee ,int loanPeriod ,
            decimal LatefeeMultiplier)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentException("title Cannot Be Empty");
            if (string.IsNullOrEmpty(catalogNumber)) throw new ArgumentException("catalogNumber Cannot Be Empty");
            if (baseLateFee <= 0) throw new ArgumentException("BaseLateFee Cannot be zero or negative");
            CatalogNumber = catalogNumber;
            Title = title;
            LoanPeriod = loanPeriod;
            BaseLateFee = baseLateFee;
            LateFeeMultiplier = LatefeeMultiplier;

        }

        public string CatalogNumber { get;  }
        public string Title { get; }
        public int LoanPeriod { get;  }
        public decimal BaseLateFee { get; private set; }
        public bool IsWithDraw { get;private set; }
        public bool IsOnLoan { get;internal set; }
        public decimal LateFeeMultiplier { get; }

        public decimal GetDailyLateFee()
        {
            return BaseLateFee * LateFeeMultiplier;
        }
        public void ChangeLateFee(decimal Amount)
        {
            if (Amount <= 0)
                throw new ArgumentException("Amount Cannot be zero or negative");
            BaseLateFee = Amount;
        }

        public void IsWidraw()
        {
            IsWithDraw = true;
        }
        public void Restore()
        {
            IsWithDraw = false;
        }
    }
}
