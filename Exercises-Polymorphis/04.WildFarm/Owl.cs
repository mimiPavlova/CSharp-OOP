using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingsize) : base(name, weight, wingsize)
        {
            this.Increasing=0.25;
        }
        public override void ProduseSoind()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public override bool CanEatFood(Food food)
        {
            if(food is Meat)
            {
                this.FoodEaten+=food.Quantity;
                return true;
            }
            return false;

        }
    }
}
