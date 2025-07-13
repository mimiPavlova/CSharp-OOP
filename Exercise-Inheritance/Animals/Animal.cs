using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private readonly string _name;
        private readonly int _age;
        private readonly string _gender;

        public string Name => this._name;
        public int Age => this._age;
        public string Gender => this._gender;

        public Animal(string name, int age, string gender)
        {

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("Name cannot be empty");
            if (age<0) { throw new AggregateException("Age cannot be negative"); }
            if (string.IsNullOrEmpty(gender)) throw new ArgumentNullException("Gener cannot be empty");
            this._name=name;
            this._age=age;
            this._gender=gender;
        }
        public virtual string ProduceSound()
        {
            throw new InvalidOperationException("Every animal must produce a specific sound");
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(this.ProduceSound());
            return sb.ToString();

        }
    }
}