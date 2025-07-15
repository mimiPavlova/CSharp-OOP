using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding
{
    public class Druid : BaseHero
    { 
        public override int Power => 80;
        public Druid(string name) : base(name)
        {
            
        }

       
        public override string CastAbility()
        => $"{this.GetType().Name} - {Name} healed for {Power}";


    }
}
