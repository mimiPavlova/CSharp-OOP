using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight,  string livingregion) : base(name, weight,  livingregion)
        {
            this.Increasing=0.10;
        }

        public override void ProduseSoind()
        {
            Console.WriteLine("Squeak");
        }
        public override bool CanEatFood(Food food)
        {
           if( food is Vegetable||food is Fruit)
            {
                this.FoodEaten+=food.Quantity;
                return true;
            }
           return false;

        }
    }
}
