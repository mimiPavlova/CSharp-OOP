using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;

public abstract class Animal
{
    private string name;
    private string favouriteFood;

    protected Animal(string name, string food)
    {
        this.name = name;
        this.favouriteFood = food;
    }

    public virtual string ExplainSelf() 
        => $"I am {this.name} and my fovourite food is {this.favouriteFood} ";

}
