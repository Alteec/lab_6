using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Library
{
    public class Person_Info
    {

        static public string GetInfo(Person person)
        {
            return $"{person.Name}: {person.Description}";
        }
    }
}
