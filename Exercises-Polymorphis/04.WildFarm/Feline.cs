using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public abstract class Feline:Mammal
    {
        protected Feline(string name, double weight,  string livingregion, string breed) : base(name, weight,  livingregion)
        {
            Breed = breed;
        }

        public string Breed {  get; set; }
        public override string ToString()
        => $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {this.LivingRegion}, {FoodEaten}]";
    }
}
