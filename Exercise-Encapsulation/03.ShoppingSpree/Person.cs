using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree;

public class Person
{
    public string Name { get; set; }
    public double Money { get; set; }
    public List<Product> Products;

    public Person(string name, double money)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
        Name=name;
        if (money < 0)
        {
            throw new ArgumentException("Money cannot be negative");
        }
        Money=money;
        Products=new List<Product>();
    }
    public void Buy(Product p)
    {
        if (this.Money>=p.Cost)
        {
            Products.Add(p);
            Console.WriteLine($"{Name} bought {p.Name}");
            Money-=p.Cost;
        }
        else
        {
            Console.WriteLine($"{Name} can't afford {p.Name}");
        }
    }
}
