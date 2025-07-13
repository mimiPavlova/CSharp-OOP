using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant;

public class HotBeverage : Beverage
{
    public HotBeverage(string name, decimal prise, double milliliters) : base(name, prise, milliliters)
    {
    }
}
