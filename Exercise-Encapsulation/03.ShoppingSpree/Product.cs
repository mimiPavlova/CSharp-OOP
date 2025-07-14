using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree;

public class Product
{
   public string Name { get; set; }
    public double Cost {  get; set; }

    public Product(string name, double cost)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
        Name=name;
        if(cost < 0)
        {
            throw new ArgumentException("Money cannot be negative");
        }
        Cost=cost;
    }
}
