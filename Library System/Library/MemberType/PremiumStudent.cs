using Library.Loan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Member_Type
{
    public class PremiumStudent : Member
    {
        public PremiumStudent(int personId, string fullName, string phone, int Discountpercentage) 
            : base(personId, fullName, phone, 10, Discountpercentage)
        {
        }

        public int ReadingPoint
        {
            get
            {
                int Point = 0;
                foreach(var item in Loan)
                {
                    if (item.Status == LoanStatus.Returned)
                        Point += 5;
                }
                return Point;
            }
        }
    }
}
