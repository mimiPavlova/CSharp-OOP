using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight , string livingregion) : base(name, weight,  livingregion)
        {
            this.Increasing=0.4;
        }

        public override void ProduseSoind()
        {
            Console.WriteLine("Woof!");
        }
        public override bool CanEatFood(Food food)
        {
           if( food is  Meat)
            {
                this.FoodEaten+=food.Quantity;

                return true;
            } return false;

        }
    }
}
