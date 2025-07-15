using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight,  string livingregion, string breed) : base(name, weight, livingregion, breed)
        {
            this.Increasing=0.3;
        }

        public override void ProduseSoind()
        {
            Console.WriteLine("Meow");
        }
        public override bool CanEatFood(Food food)
        {
           if( food is Vegetable||food is Meat)
            {
                this.FoodEaten+=food.Quantity;
                return true;
            }
           return false;
        }
    }
}
