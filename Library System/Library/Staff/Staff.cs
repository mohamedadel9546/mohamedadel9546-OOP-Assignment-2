using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Staff
{
    public class Staff : Person
    {
        protected Staff(int personId, string fullName, string phone, DateTime Hiredate, decimal Monthlysalary) 
            : base(personId, fullName, phone)
        {
            HireDate = Hiredate;
            MonthlySalary = Monthlysalary;
        }
        public DateTime HireDate { get; }
        public decimal MonthlySalary { get; private set; }

        public void GiveRaise(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount Cannot Zero Or Negative");
            MonthlySalary += MonthlySalary * (amount/100);
        }
    }
}
