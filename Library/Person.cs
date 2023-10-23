using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Library
{
    public class Person
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Person(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
    }
}
