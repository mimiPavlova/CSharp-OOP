using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight,  string livingregion, string breed) : base(name, weight,  livingregion, breed)
        {
            this.Increasing=1.0;
        }

        public override void ProduseSoind()
        {
            Console.WriteLine("ROAR!!!");
        }
        public override bool CanEatFood(Food food)
        {
            if( food is Meat)
            {
                this.FoodEaten+=food.Quantity;
                return true;
            }
            return false;


        }
    }
}
