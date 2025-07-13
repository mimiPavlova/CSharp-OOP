using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;

public class MainDish : Food
{
    public MainDish(string name, decimal prise, double grams) : base(name, prise, grams)
    {
    }
}
