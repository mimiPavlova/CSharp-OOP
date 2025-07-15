using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public class Hen : Bird
    {
             
        public Hen(string name, double weight, double wingsize) : base(name, weight,  wingsize)
        {
            this.Increasing=0.35;
        }
        public override void ProduseSoind()
        {
            Console.WriteLine("Cluck");
        }
        public override bool CanEatFood(Food food)
        {
            this.Weight+=food.Quantity*this.Increasing;
            return true;
        }
    }
}
