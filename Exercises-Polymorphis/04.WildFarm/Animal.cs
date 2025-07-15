using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public abstract class Animal
    {
        
        
        public double Increasing { get; protected set; }
        public string Name { get; set; }
        public double Weight {  get; set; }
        public int FoodEaten
        {
            get; set;
        }

        protected Animal(string name, double weight)
        {
            Name=name;
            Weight=weight;
            
        }

        public abstract void  ProduseSoind();
        public void GainWeight()
        {
            Weight+=FoodEaten*Increasing;
        }
       public abstract bool CanEatFood(Food food);
    }
}
