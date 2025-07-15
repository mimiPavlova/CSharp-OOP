using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm
{
    public  abstract class Bird:Animal
    {
        public Bird(string name, double weight, double wingsize) : base(name, weight)
        {
            WingSize = wingsize;
        }

        public double WingSize
        {
            get; set;
        }

        public override string ToString()
        => $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}
