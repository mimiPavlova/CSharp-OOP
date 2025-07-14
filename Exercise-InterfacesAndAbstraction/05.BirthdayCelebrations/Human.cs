using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations
{
    public class Human : ICitizen, IBirthdate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }

        public Human(string id, int age, string name, string birthdate)
        {
            Id=name;
            Name=name;
            Age=age;
            Birthdate=birthdate;
        }
    }
}
