using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
   public abstract class Mammal:Animal
    {
        public Mammal(string name, double weight,  string livingregion) : base(name, weight)
        {
            LivingRegion = livingregion;
            
        }

        public string LivingRegion {  get; set; }

        public override string ToString()
        => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        
    }
}
