using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl
{
    public class Human : ICitizen
    {
        public string Id {  get; set; }
        public string Name { get; set; }
        public int Age {  get; set; }

        public Human(string id, int age,string name )
        {
            Id=name;
            Name=name;
            Age=age;
        }
    }
}
