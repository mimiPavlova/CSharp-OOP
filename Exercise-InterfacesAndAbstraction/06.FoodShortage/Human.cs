using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage;

public class Human : ICitizen, IBirthdate, IBuyer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Birthdate { get; set; }
    public int Food { get; private set; }

    public Human( string name,string id,int age, string birthdate)
    { 
        Id=name;
        Name=name;
        Age=age;
        Birthdate=birthdate;
    }

    public void BuyFood()
    {
        Food+=10;
    }
}