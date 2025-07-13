using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Starter : Food
    {
        public Starter(string name, decimal prise, double grams) : base(name, prise, grams)
        {
        }
    }
}
