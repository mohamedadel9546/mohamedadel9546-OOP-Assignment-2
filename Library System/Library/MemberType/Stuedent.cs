using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Member_Type
{
    public class Stuedent : Member
    {
        public Stuedent(int personId, string fullName, string phone)
            : base(personId, fullName, phone, 3, 0)
        {
        }
    }
}
