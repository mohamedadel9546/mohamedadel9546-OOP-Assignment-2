using System;
using System.Collections.Generic;
using System.Text;

namespace Library;

public class Person
{
    protected Person(int personId, string fullName, string phone)
    {
        PersonId = personId;
        FullName = fullName;
        Phone = phone;
    }

    public int PersonId { get;  }
    public string FullName { get;  }
    public string Phone { get;  }
    
}
