using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding;

public abstract class BaseHero:IHero
{
    public string Name {  get; protected set; }
    public abstract int Power { get;  }

    protected BaseHero(string name)
    {
        Name=name;
    }

    public abstract string CastAbility();
}
