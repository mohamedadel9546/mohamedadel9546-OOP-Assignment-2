using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Staff
{
    public class Shelver : Staff
    {
        public Shelver(int personId, string fullName, string phone, DateTime Hiredate, decimal Monthlysalary,
             string section) 
            : base(personId, fullName, phone, Hiredate, Monthlysalary)
        {
            Section = section;
        }
        public  string Section { get;private set; }
        public void ReAssign(string section)
        {
            Section = section;
        }
        
    }
}
