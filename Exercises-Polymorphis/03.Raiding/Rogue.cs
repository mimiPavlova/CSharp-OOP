using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding;

public class Rogue : BaseHero
{
    public Rogue(string name) : base(name)
    {
        
    }

    public override int Power => 80;

    public override string CastAbility()
    => $"{this.GetType().Name} - {Name} hit for {Power} damage";
}
