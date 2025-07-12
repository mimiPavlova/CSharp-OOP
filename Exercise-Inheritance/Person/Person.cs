using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private readonly string _name;
        private readonly int _age;

        public string Name => _name;
        public int Age => _age;
        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }
        public override string ToString()

        {

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{this.GetType().Name} -> ");

            stringBuilder.Append($"Name: {Name}, Age: {Age}");
            return stringBuilder.ToString();

        }
    }
}
