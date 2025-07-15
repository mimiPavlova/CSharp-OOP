using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
            
        }

        public override int Power => 100;

        public override string CastAbility()
        => $"{this.GetType().Name} - {Name} healed for {Power}";


    }
}
