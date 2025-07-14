using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage;

public class Rebel : IBuyer
{
    string Name { get; set; }
    int Age { get; set; }
    public string Group { get; set; }

    public Rebel(string name, int age, string group)
    {
        Name=name;
        Age=age;
        Group=group;
    }

    public int Food { get; private set; }


    public void BuyFood()
    {
        Food+=5;
    }
}